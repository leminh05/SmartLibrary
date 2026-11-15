namespace SmartLibrary;

// Abstract base for everyone in the system; Member and Librarian describe themselves differently.
public abstract class Person : IReportable
{
    public string Id { get; }
    public string Name { get; }

    protected Person(string id, string name)
    {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID is required.", nameof(id));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required.", nameof(name));
        Id = id.Trim();
        Name = name.Trim();
    }

    public abstract string Role { get; }
    public abstract string GenerateReport();

    public override string ToString() => $"{Id} - {Name}";
}
