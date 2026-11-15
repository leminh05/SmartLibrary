namespace SmartLibrary;

// Staff can sign in. Each role states its own permissions, so the UI asks the object
// ("can you manage members?") instead of checking role names (polymorphism).
public abstract class Staff : Person
{
    public string PasswordHash { get; }

    protected Staff(string id, string name, string passwordHash) : base(id, name)
    {
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentException("Password hash is required.", nameof(passwordHash));
        PasswordHash = passwordHash;
    }

    public abstract bool CanManageMembers { get; }
    public abstract bool CanResetData { get; }

    public bool VerifyPassword(string password) => PasswordHasher.Verify(password, PasswordHash);
}
