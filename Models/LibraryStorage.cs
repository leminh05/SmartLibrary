using System.Text.Json;

namespace SmartLibrary;

// Saves/loads the library as JSON. Objects are flattened to plain records with a "Type"/"Role" field,
// and rebuilt through ItemFactory and the normal Library methods, so every validation rule still applies.
public static class LibraryStorage
{
    private record ItemData(string Type, string Id, string Title, string? BorrowerId, DateTime? DueDate);
    private record MemberData(string Id, string Name, decimal FinesOwed);
    private record StaffData(string Role, string Id, string Name, string PasswordHash, string? Shift);
    private record LibraryData(List<ItemData> Items, List<MemberData> Members, List<StaffData> Staff);

    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public static void Save(Library library, string path)
    {
        var data = new LibraryData(
            library.Items.Select(i => new ItemData(i.Type, i.Id, i.Title, i.BorrowerId, i.DueDate)).ToList(),
            library.Members.Select(m => new MemberData(m.Id, m.Name, m.FinesOwed)).ToList(),
            library.Staff.Select(s => new StaffData(s.Role, s.Id, s.Name, s.PasswordHash, (s as Librarian)?.Shift)).ToList());

        // Write to a temp file first so a crash mid-save never leaves a half-written data file.
        string temp = path + ".tmp";
        File.WriteAllText(temp, JsonSerializer.Serialize(data, Options));
        File.Move(temp, path, overwrite: true);
    }

    // shortcut: DigitalMedia.AccessRevoked is not saved; it only matters until the item is borrowed again.
    public static Library Load(string path)
    {
        var data = JsonSerializer.Deserialize<LibraryData>(File.ReadAllText(path), Options)
                   ?? throw new JsonException("Data file is empty.");
        var library = new Library();

        foreach (var s in data.Staff)
            library.AddStaff(s.Role switch
            {
                "Admin" => new Admin(s.Id, s.Name, s.PasswordHash),
                "Librarian" => new Librarian(s.Id, s.Name, s.Shift ?? "", s.PasswordHash),
                _ => throw new JsonException($"Unknown staff role: {s.Role}"),
            });

        foreach (var m in data.Members)
            library.AddMember(m.Id, m.Name).AddFine(m.FinesOwed);

        foreach (var i in data.Items)
        {
            var item = ItemFactory.Create(i.Type, i.Id, i.Title);
            library.AddItem(item);
            // Re-create the loan with the same due date: borrowed on (due - loan length).
            if (i.BorrowerId != null && i.DueDate is DateTime due)
                library.CheckOut(item.Id, i.BorrowerId, due.AddDays(-item.LoanDays));
        }
        return library;
    }
}
