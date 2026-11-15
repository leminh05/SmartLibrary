namespace SmartLibrary;

public class Member
{
    public string Id { get; }
    public string Name { get; }
    public decimal FinesOwed { get; private set; }

    public Member(string id, string name)
    {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Member ID is required.", nameof(id));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Member name is required.", nameof(name));
        Id = id.Trim();
        Name = name.Trim();
    }

    public void AddFine(decimal amount)
    {
        if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
        FinesOwed += amount;
    }

    public override string ToString() => $"{Id} - {Name}";
}
