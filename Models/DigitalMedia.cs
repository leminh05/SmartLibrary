namespace SmartLibrary;

public class DigitalMedia : LibraryItem
{
    public bool AccessRevoked { get; private set; }

    public DigitalMedia(string id, string title) : base(id, title) { }

    public override int LoanDays => 3;

    public override void CheckOut(string memberId, DateTime today)
    {
        base.CheckOut(memberId, today);
        AccessRevoked = false;
    }

    // Digital media never costs a fee: access is simply revoked when the loan expires.
    public override decimal CalculateLateFee(DateTime returnDate)
    {
        if (DaysLate(returnDate) > 0) AccessRevoked = true;
        return 0m;
    }

    public override string GenerateReport() =>
        base.GenerateReport() + " | No fee, access revoked when late" + (AccessRevoked ? " (REVOKED)" : "");
}
