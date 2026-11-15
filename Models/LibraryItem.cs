namespace SmartLibrary;

// Abstract base: every item can be lent, but each subclass decides its own loan length and late fee.
public abstract class LibraryItem
{
    public string Id { get; }
    public string Title { get; }

    // Encapsulation: loan state can only change through CheckOut / CheckIn.
    public string? BorrowerId { get; private set; }
    public DateTime? DueDate { get; private set; }

    protected LibraryItem(string id, string title)
    {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Id is required.", nameof(id));
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required.", nameof(title));
        Id = id.Trim();
        Title = title.Trim();
    }

    public string Type => GetType().Name;
    public bool IsCheckedOut => BorrowerId != null;
    public string Status => IsCheckedOut ? $"Borrowed by {BorrowerId}" : "Available";

    public abstract int LoanDays { get; }
    public abstract decimal CalculateLateFee(DateTime returnDate);

    public int DaysLate(DateTime returnDate) =>
        DueDate is DateTime due && returnDate.Date > due ? (returnDate.Date - due).Days : 0;

    public virtual void CheckOut(string memberId, DateTime today)
    {
        if (IsCheckedOut) throw new InvalidOperationException($"\"{Title}\" is already borrowed by {BorrowerId}.");
        BorrowerId = memberId;
        DueDate = today.Date.AddDays(LoanDays);
    }

    public void CheckIn()
    {
        BorrowerId = null;
        DueDate = null;
    }

    public override string ToString() => $"{Id} - {Title} ({Type}) - {Status}";
}
