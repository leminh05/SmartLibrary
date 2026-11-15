namespace SmartLibrary;

// Holds all items and members in memory and enforces the lending rules.
// shortcut: data lives in memory and resets on restart; add a JSON file or database if it must persist.
public class Library
{
    private const StringComparison IgnoreCase = StringComparison.OrdinalIgnoreCase;

    private readonly List<LibraryItem> items = new();
    private readonly List<Member> members = new();
    private readonly List<Librarian> librarians = new();

    public IReadOnlyList<LibraryItem> Items => items;
    public IReadOnlyList<Member> Members => members;
    public IReadOnlyList<Librarian> Librarians => librarians;

    // Dashboard statistics
    public int BorrowedCount => items.Count(i => i.IsCheckedOut);
    public List<LibraryItem> Overdue(DateTime today) => items.Where(i => i.IsOverdue(today)).ToList();
    public decimal TotalFinesOwed => members.Sum(m => m.FinesOwed);

    // Interface polymorphism: items and people are unrelated classes, but all can generate a report.
    public IEnumerable<IReportable> Reportables =>
        librarians.Cast<IReportable>().Concat(members).Concat(items);

    public void AddLibrarian(Librarian librarian) => librarians.Add(librarian);

    public void PayFine(string memberId, decimal amount) => GetMember(memberId).PayFine(amount);

    public void AddItem(LibraryItem item)
    {
        if (items.Any(i => i.Id.Equals(item.Id, IgnoreCase)))
            throw new InvalidOperationException($"An item with ID {item.Id} already exists.");
        items.Add(item);
    }

    public void AddMember(string id, string name)
    {
        var member = new Member(id, name);
        if (members.Any(m => m.Id.Equals(member.Id, IgnoreCase)))
            throw new InvalidOperationException($"A member with ID {member.Id} already exists.");
        members.Add(member);
    }

    public void RemoveMember(string id)
    {
        var member = GetMember(id);
        if (items.Any(i => i.BorrowerId == member.Id))
            throw new InvalidOperationException($"{member.Name} still has borrowed items.");
        if (member.FinesOwed > 0)
            throw new InvalidOperationException($"{member.Name} still owes {member.FinesOwed:N0} VND.");
        members.Remove(member);
    }

    public List<LibraryItem> Search(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return items.ToList();
        text = text.Trim();
        return items.Where(i => i.Title.Contains(text, IgnoreCase)
                             || i.Id.Contains(text, IgnoreCase)
                             || i.Type.Contains(text, IgnoreCase)).ToList();
    }

    public void CheckOut(string itemId, string memberId, DateTime today)
    {
        var item = GetItem(itemId);
        var member = GetMember(memberId);
        item.CheckOut(member.Id, today);
    }

    // Returns the late fee charged to the borrower.
    public decimal CheckIn(string itemId, DateTime returnDate)
    {
        var item = GetItem(itemId);
        if (item.BorrowerId is not string borrowerId)
            throw new InvalidOperationException($"\"{item.Title}\" is not borrowed.");

        decimal fee = item.CalculateLateFee(returnDate); // polymorphism: each subclass computes its own fee
        GetMember(borrowerId).AddFine(fee);
        item.CheckIn();
        return fee;
    }

    private LibraryItem GetItem(string id) =>
        items.FirstOrDefault(i => i.Id.Equals(id, IgnoreCase))
        ?? throw new InvalidOperationException($"No item with ID {id}.");

    private Member GetMember(string id) =>
        members.FirstOrDefault(m => m.Id.Equals(id, IgnoreCase))
        ?? throw new InvalidOperationException($"No member with ID {id}.");

    public static Library CreateSample()
    {
        var library = new Library();
        library.AddItem(new Book("B001", "Clean Code"));
        library.AddItem(new Book("B002", "Design Patterns"));
        library.AddItem(new Book("B003", "The Pragmatic Programmer"));
        library.AddItem(new Magazine("M001", "Tech Monthly - November 2026"));
        library.AddItem(new Magazine("M002", "Science Weekly - Issue 45"));
        library.AddItem(new DigitalMedia("D001", "C# Fundamentals (Video Course)"));
        library.AddItem(new DigitalMedia("D002", "OOP in Practice (E-book)"));
        library.AddMember("S001", "Nguyen Van A");
        library.AddMember("S002", "Tran Thi B");
        library.AddLibrarian(new Librarian("L001", "Le Van C", "Morning"));
        return library;
    }
}
