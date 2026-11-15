namespace SmartLibrary;

public class Book : LibraryItem
{
    public const decimal FeePerDay = 5000m;

    public Book(string id, string title) : base(id, title) { }

    public override int LoanDays => 14;

    // Physical books are charged for every day they are late.
    public override decimal CalculateLateFee(DateTime returnDate) => DaysLate(returnDate) * FeePerDay;

    public override string GenerateReport() => base.GenerateReport() + $" | Late fee: {FeePerDay:N0} VND per day";
}
