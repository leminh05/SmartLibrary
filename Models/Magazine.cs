namespace SmartLibrary;

public class Magazine : LibraryItem
{
    public const decimal ReplacementFee = 50000m;

    public Magazine(string id, string title) : base(id, title) { }

    public override int LoanDays => 7;

    // Magazines have a flat replacement fee once late, no matter how many days.
    public override decimal CalculateLateFee(DateTime returnDate) => DaysLate(returnDate) > 0 ? ReplacementFee : 0m;
}
