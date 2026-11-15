namespace SmartLibrary.Tests;

// Polymorphism: the same CheckIn call gives a different fee for each item type.
public class LateFeeTests
{
    private static readonly DateTime Day = new(2026, 11, 1);
    private readonly Library lib = Library.CreateSample();

    [Fact]
    public void Book_IsChargedPerLateDay()
    {
        lib.CheckOut("B001", "S001", Day); // due Day + 14
        Assert.Equal(3 * Book.FeePerDay, lib.CheckIn("B001", Day.AddDays(17)));
    }

    [Fact]
    public void Magazine_HasFlatFee()
    {
        lib.CheckOut("M001", "S001", Day); // due Day + 7
        Assert.Equal(Magazine.ReplacementFee, lib.CheckIn("M001", Day.AddDays(30)));
    }

    [Fact]
    public void DigitalMedia_HasNoFee_ButAccessIsRevoked()
    {
        lib.CheckOut("D001", "S001", Day); // due Day + 3
        var item = (DigitalMedia)lib.Items.First(i => i.Id == "D001");
        Assert.Equal(0m, lib.CheckIn("D001", Day.AddDays(10)));
        Assert.True(item.AccessRevoked);
    }

    [Fact]
    public void OnTimeReturn_IsFree()
    {
        lib.CheckOut("B002", "S001", Day);
        Assert.Equal(0m, lib.CheckIn("B002", Day.AddDays(14)));
    }

    [Fact]
    public void Fee_IsAddedToBorrower()
    {
        lib.CheckOut("B001", "S001", Day);
        lib.CheckIn("B001", Day.AddDays(16));
        Assert.Equal(2 * Book.FeePerDay, lib.Members.First(m => m.Id == "S001").FinesOwed);
    }
}
