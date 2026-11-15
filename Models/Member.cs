namespace SmartLibrary;

public class Member : Person
{
    // Encapsulation: fines can only change through AddFine / PayFine, which validate the amount.
    public decimal FinesOwed { get; private set; }

    public Member(string id, string name) : base(id, name) { }

    public override string Role => "Member";

    public void AddFine(decimal amount)
    {
        if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
        FinesOwed += amount;
    }

    public void PayFine(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Payment must be greater than 0.");
        if (amount > FinesOwed) throw new ArgumentException($"{Name} only owes {FinesOwed:N0} VND.");
        FinesOwed -= amount;
    }

    public override string GenerateReport() => $"[Member]    {Id} - {Name} | Fines owed: {FinesOwed:N0} VND";
}
