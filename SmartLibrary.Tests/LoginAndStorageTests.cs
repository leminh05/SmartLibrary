namespace SmartLibrary.Tests;

public class LoginAndStorageTests : IDisposable
{
    private readonly Library lib = Library.CreateSample();
    private readonly string path = Path.Combine(Path.GetTempPath(), $"smartlibrary-{Guid.NewGuid()}.json");

    public void Dispose() => File.Delete(path);

    [Fact]
    public void Login_WithCorrectPassword_ReturnsStaff()
    {
        Assert.IsType<Admin>(lib.Login("A001", "admin123"));
        Assert.IsType<Librarian>(lib.Login(" l001 ", "librarian123"));
    }

    [Theory]
    [InlineData("A001", "wrong")]
    [InlineData("A001", "")]
    [InlineData("X999", "admin123")]
    public void Login_WithWrongIdOrPassword_ReturnsNull(string id, string password) =>
        Assert.Null(lib.Login(id, password));

    [Fact]
    public void Passwords_AreNotStoredInPlainText()
    {
        Assert.All(lib.Staff, s => Assert.DoesNotContain("admin123", s.PasswordHash));
        Assert.All(lib.Staff, s => Assert.DoesNotContain("librarian123", s.PasswordHash));
        Assert.False(PasswordHasher.Verify("x", "not-a-valid-hash"));
    }

    [Fact]
    public void Permissions_DependOnRole()
    {
        Staff admin = lib.Login("A001", "admin123")!;
        Staff librarian = lib.Login("L001", "librarian123")!;
        Assert.True(admin.CanManageMembers && admin.CanResetData);
        Assert.False(librarian.CanManageMembers || librarian.CanResetData);
    }

    [Fact]
    public void SaveThenLoad_KeepsItemsLoansFinesAndAccounts()
    {
        var day = new DateTime(2026, 11, 1);
        lib.CheckOut("M001", "S001", day);
        lib.CheckIn("M001", day.AddDays(30));          // S001 owes the magazine fee
        lib.CheckOut("B002", "S002", day);              // still borrowed
        lib.AddItem(ItemFactory.Create("DigitalMedia", "D009", "New Podcast"));

        LibraryStorage.Save(lib, path);
        var loaded = LibraryStorage.Load(path);

        Assert.Equal(lib.Items.Select(i => (i.Type, i.Id, i.BorrowerId, i.DueDate)),
                     loaded.Items.Select(i => (i.Type, i.Id, i.BorrowerId, i.DueDate)));
        Assert.Equal(Magazine.ReplacementFee, loaded.Members.First(m => m.Id == "S001").FinesOwed);
        Assert.IsType<DigitalMedia>(loaded.Items.First(i => i.Id == "D009"));
        Assert.NotNull(loaded.Login("A001", "admin123"));
    }

    [Fact]
    public void Load_DamagedFile_Throws()
    {
        File.WriteAllText(path, "{ not json");
        Assert.ThrowsAny<System.Text.Json.JsonException>(() => LibraryStorage.Load(path));
    }
}
