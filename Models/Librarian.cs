namespace SmartLibrary;

public class Librarian : Person
{
    public string Shift { get; }

    public Librarian(string id, string name, string shift) : base(id, name)
    {
        Shift = string.IsNullOrWhiteSpace(shift) ? "Morning" : shift.Trim();
    }

    public override string Role => "Librarian";

    public override string GenerateReport() => $"[Librarian] {Id} - {Name} | Shift: {Shift}";
}
