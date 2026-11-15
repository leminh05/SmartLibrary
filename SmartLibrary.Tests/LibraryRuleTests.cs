namespace SmartLibrary.Tests;

public class LibraryRuleTests
{
    private static readonly DateTime Day = new(2026, 11, 1);
    private readonly Library lib = Library.CreateSample();

    [Fact]
    public void Item_CannotBeBorrowedTwice()
    {
        lib.CheckOut("B003", "S002", Day);
        Assert.Throws<InvalidOperationException>(() => lib.CheckOut("B003", "S001", Day));
    }

    [Fact]
    public void UnknownMember_IsRejected() =>
        Assert.Throws<InvalidOperationException>(() => lib.CheckOut("B001", "S999", Day));

    [Fact]
    public void ReturningAnItemThatIsNotBorrowed_IsRejected() =>
        Assert.Throws<InvalidOperationException>(() => lib.CheckIn("B001", Day));

    [Fact]
    public void MemberWithLoans_CannotBeRemoved()
    {
        lib.CheckOut("B003", "S002", Day);
        Assert.Throws<InvalidOperationException>(() => lib.RemoveMember("S002"));
    }

    [Fact]
    public void MemberWithFines_CannotBeRemoved_UntilPaid()
    {
        lib.CheckOut("M001", "S002", Day);
        lib.CheckIn("M001", Day.AddDays(30));
        Assert.Throws<InvalidOperationException>(() => lib.RemoveMember("S002"));

        lib.PayFine("S002", Magazine.ReplacementFee);
        lib.RemoveMember("S002");
        Assert.DoesNotContain(lib.Members, m => m.Id == "S002");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1000)]
    [InlineData(999_999)]
    public void InvalidPayment_IsRejected(decimal amount)
    {
        lib.CheckOut("M001", "S001", Day);
        lib.CheckIn("M001", Day.AddDays(30));
        Assert.Throws<ArgumentException>(() => lib.PayFine("S001", amount));
        Assert.Equal(Magazine.ReplacementFee, lib.TotalFinesOwed);
    }

    [Fact]
    public void DuplicateIds_AreRejected()
    {
        Assert.Throws<InvalidOperationException>(() => lib.AddItem(new Book("b001", "Duplicate")));
        Assert.Throws<InvalidOperationException>(() => lib.AddMember("s001", "Duplicate"));
    }

    [Fact]
    public void Search_MatchesTitleIdAndType()
    {
        Assert.Single(lib.Search("clean"));
        Assert.Equal(2, lib.Search("magazine").Count);
        Assert.Equal(lib.Items.Count, lib.Search("  ").Count);
    }

    [Fact]
    public void Overdue_DependsOnDate()
    {
        lib.CheckOut("B003", "S002", Day); // due Day + 14
        Assert.Empty(lib.Overdue(Day.AddDays(14)));
        Assert.Single(lib.Overdue(Day.AddDays(15)));
    }

    [Fact]
    public void Factory_BuildsTheRightSubclass()
    {
        Assert.IsType<Magazine>(ItemFactory.Create("Magazine", "M9", "X"));
        Assert.Throws<ArgumentException>(() => ItemFactory.Create("Car", "C1", "X"));
    }

    [Fact]
    public void EveryObject_ReportsItself()
    {
        var reports = lib.Reportables.Select(r => r.GenerateReport()).ToList();
        Assert.Equal(lib.Staff.Count + lib.Members.Count + lib.Items.Count, reports.Count);
        Assert.Contains(reports, r => r.StartsWith("[Admin]"));
        Assert.Contains(reports, r => r.Contains("per day"));
    }
}
