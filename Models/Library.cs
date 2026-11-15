namespace SmartLibrary;

// Holds all items, members and staff, and enforces the lending rules. LibraryStorage saves it to JSON.
public class Library
{
    private const StringComparison IgnoreCase = StringComparison.OrdinalIgnoreCase;

    private readonly List<LibraryItem> items = new();
    private readonly List<Member> members = new();
    private readonly List<Staff> staff = new();

    public IReadOnlyList<LibraryItem> Items => items;
    public IReadOnlyList<Member> Members => members;
    public IReadOnlyList<Staff> Staff => staff;

    // Dashboard statistics
    public int BorrowedCount => items.Count(i => i.IsCheckedOut);
    public List<LibraryItem> Overdue(DateTime today) => items.Where(i => i.IsOverdue(today)).ToList();
    public decimal TotalFinesOwed => members.Sum(m => m.FinesOwed);

    // Interface polymorphism: items and people are unrelated classes, but all can generate a report.
    public IEnumerable<IReportable> Reportables =>
        staff.Cast<IReportable>().Concat(members).Concat(items);

    public void AddStaff(Staff person)
    {
        if (staff.Any(s => s.Id.Equals(person.Id, IgnoreCase)))
            throw new InvalidOperationException($"A staff account with ID {person.Id} already exists.");
        staff.Add(person);
    }

    // Returns the signed-in staff member, or null when the ID or password is wrong.
    public Staff? Login(string id, string password)
    {
        var account = staff.FirstOrDefault(s => s.Id.Equals(id.Trim(), IgnoreCase));
        return account != null && account.VerifyPassword(password) ? account : null;
    }

    public void PayFine(string memberId, decimal amount) => GetMember(memberId).PayFine(amount);

    public void AddItem(LibraryItem item)
    {
        if (items.Any(i => i.Id.Equals(item.Id, IgnoreCase)))
            throw new InvalidOperationException($"An item with ID {item.Id} already exists.");
        items.Add(item);
    }

    public Member AddMember(string id, string name)
    {
        var member = new Member(id, name);
        if (members.Any(m => m.Id.Equals(member.Id, IgnoreCase)))
            throw new InvalidOperationException($"A member with ID {member.Id} already exists.");
        members.Add(member);
        return member;
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
        AddDemoStaff(library);
        return library;
    }

    // Demo accounts (see README): A001 / admin123, L001 / librarian123
    public static void AddDemoStaff(Library library)
    {
        library.AddStaff(new Admin("A001", "Pham Thi D", PasswordHasher.Hash("admin123")));
        library.AddStaff(new Librarian("L001", "Le Van C", "Morning", PasswordHasher.Hash("librarian123")));
    }

    // Full demo data set used by the app (50 books, 40 members, loans); tests use the small CreateSample.
    public static Library CreateDemo() => DemoData.Create(DateTime.Today);
}
