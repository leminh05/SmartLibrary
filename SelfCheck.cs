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
    }

    private static void Check(bool ok, string rule)
    {
        if (!ok) throw new Exception("Self-check failed: " + rule);
    }

    private static bool Throws(Action action)
    {
        try { action(); return false; }
        catch (InvalidOperationException) { return true; }
    }
}
