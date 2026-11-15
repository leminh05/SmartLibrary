namespace SmartLibrary;

// Factory pattern: the UI asks for an item by type name and never calls subclass constructors itself.
public static class ItemFactory
{
    public static readonly string[] Types = { nameof(Book), nameof(Magazine), nameof(DigitalMedia) };

    public static LibraryItem Create(string type, string id, string title) => type switch
    {
        nameof(Book) => new Book(id, title),
        nameof(Magazine) => new Magazine(id, title),
        nameof(DigitalMedia) => new DigitalMedia(id, title),
        _ => throw new ArgumentException($"Unknown item type: {type}"),
    };
}
