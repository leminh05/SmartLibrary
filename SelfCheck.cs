namespace SmartLibrary;

// Runs at startup in Debug builds; throws if a lending rule is broken.
internal static class SelfCheck
{
    public static void Run()
    {
        var lib = Library.CreateSample();
        var day = new DateTime(2026, 11, 1);

        lib.CheckOut("B001", "S001", day); // due day + 14
        Check(lib.CheckIn("B001", day.AddDays(17)) == 3 * Book.FeePerDay, "book is charged per late day");

        lib.CheckOut("M001", "S001", day); // due day + 7
        Check(lib.CheckIn("M001", day.AddDays(9)) == Magazine.ReplacementFee, "magazine has a flat fee");

        lib.CheckOut("D001", "S002", day); // due day + 3
        var digital = (DigitalMedia)lib.Items.First(i => i.Id == "D001");
        Check(lib.CheckIn("D001", day.AddDays(10)) == 0 && digital.AccessRevoked, "digital media: no fee, access revoked");

        lib.CheckOut("B002", "S002", day);
        Check(lib.CheckIn("B002", day.AddDays(14)) == 0, "on-time return is free");

        Check(lib.Members[0].FinesOwed == 3 * Book.FeePerDay + Magazine.ReplacementFee, "fines go to the borrower");
        Check(Throws(() => lib.CheckOut("B001", "S999", day)), "unknown member is rejected");

        lib.CheckOut("B003", "S002", day);
        Check(Throws(() => lib.CheckOut("B003", "S001", day)), "item cannot be borrowed twice");
        Check(Throws(() => lib.RemoveMember("S002")), "member with loans cannot be removed");
        Check(Throws(() => lib.CheckIn("B001", day)), "returning an item that is not borrowed is rejected");

        Check(lib.Search("clean").Count == 1 && lib.Search("magazine").Count == 2, "search by title and type");

        // Dashboard statistics
        Check(lib.BorrowedCount == 1 && lib.Overdue(day.AddDays(20)).Count == 1 && lib.Overdue(day).Count == 0, "overdue count");

        // Encapsulation: fines only change through validated methods
        var a = lib.Members[0];
        Check(Throws(() => lib.PayFine(a.Id, a.FinesOwed + 1)), "cannot overpay");
        Check(Throws(() => lib.PayFine(a.Id, 0)), "payment must be positive");
        lib.PayFine(a.Id, Book.FeePerDay);
        Check(a.FinesOwed == 2 * Book.FeePerDay + Magazine.ReplacementFee, "payment reduces fines");
        Check(lib.TotalFinesOwed == a.FinesOwed, "total fines");

        // Factory
        Check(ItemFactory.Create("Magazine", "M9", "X") is Magazine, "factory builds the right subclass");
        Check(Throws(() => ItemFactory.Create("Car", "C1", "X")), "factory rejects unknown type");
        Check(Throws(() => lib.AddItem(new Book("b001", "Duplicate"))), "duplicate item ID rejected");

        // Interface polymorphism: every report is different and mentions its own rule
        var reports = lib.Reportables.Select(r => r.GenerateReport()).ToList();
        Check(reports.Count == lib.Librarians.Count + lib.Members.Count + lib.Items.Count, "all reportables listed");
        Check(reports.Any(r => r.StartsWith("[Librarian]")) && reports.Any(r => r.Contains("REVOKED")), "reports differ by type");
    }

    private static void Check(bool ok, string rule)
    {
        if (!ok) throw new Exception("Self-check failed: " + rule);
    }

    private static bool Throws(Action action)
    {
        try { action(); return false; }
        catch (Exception ex) when (ex is InvalidOperationException or ArgumentException) { return true; }
    }
}
