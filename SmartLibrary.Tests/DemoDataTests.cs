namespace SmartLibrary.Tests;

public class DemoDataTests
{
    private static readonly DateTime Today = new(2026, 11, 19);
    private readonly Library lib = DemoData.Create(Today);

    [Fact]
    public void Has50Books_And40Members()
    {
        Assert.Equal(50, lib.Items.OfType<Book>().Count());
        Assert.Equal(40, lib.Members.Count);
    }

    [Fact]
    public void LoansFinesAndOverdue_AreAsDescribed()
    {
        Assert.Equal(34, lib.BorrowedCount);
        Assert.Equal(8, lib.Overdue(Today).Count);
        Assert.Equal(18 * Book.FeePerDay, lib.TotalFinesOwed); // 3 + 4 + 5 + 6 late days
    }

    [Fact]
    public void SurvivesSaveAndLoad()
    {
        string path = Path.Combine(Path.GetTempPath(), $"smartlibrary-demo-{Guid.NewGuid()}.json");
        try
        {
            LibraryStorage.Save(lib, path);
            var loaded = LibraryStorage.Load(path);
            Assert.Equal(lib.Items.Count, loaded.Items.Count);
            Assert.Equal("Dế Mèn Phiêu Lưu Ký - Tô Hoài", loaded.Items.First(i => i.Id == "B031").Title);
            Assert.Equal(lib.TotalFinesOwed, loaded.TotalFinesOwed);
        }
        finally
        {
            File.Delete(path);
        }
    }
}
