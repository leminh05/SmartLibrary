namespace SmartLibrary;

// Daily desk work: search, check out/in, add items, take fine payments.
public class Librarian : Staff
{
    public string Shift { get; }

    public Librarian(string id, string name, string shift, string passwordHash) : base(id, name, passwordHash)
    {
        Shift = string.IsNullOrWhiteSpace(shift) ? "Morning" : shift.Trim();
    }

    public override string Role => "Librarian";
    public override bool CanManageMembers => false;
    public override bool CanResetData => false;

    public override string GenerateReport() => $"[Librarian] {Id} - {Name} | Shift: {Shift}";
}
