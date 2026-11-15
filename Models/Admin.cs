namespace SmartLibrary;

// Everything a librarian does, plus adding/removing members and resetting data.
public class Admin : Staff
{
    public Admin(string id, string name, string passwordHash) : base(id, name, passwordHash) { }

    public override string Role => "Admin";
    public override bool CanManageMembers => true;
    public override bool CanResetData => true;

    public override string GenerateReport() => $"[Admin]     {Id} - {Name} | Full access";
}
