namespace SmartLibrary;

// Interface: a capability shared by unrelated hierarchies (LibraryItem and Person).
// An abstract class says what something *is*; an interface says what it *can do*.
public interface IReportable
{
    string GenerateReport();
}
