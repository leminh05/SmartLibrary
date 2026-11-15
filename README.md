# SmartLibrary

WinForms app (C#, .NET 10) for librarians: search items, check items out and in, manage members.

## Run

Open `SmartLibrary.csproj` in Visual Studio and press **F5**.
In Debug builds, `SelfCheck.Run()` checks the lending rules at startup.

## OOP design

```mermaid
classDiagram
    class LibraryItem {
        <<abstract>>
        +Id
        +Title
        +BorrowerId (private set)
        +DueDate (private set)
        +LoanDays*
        +CalculateLateFee(returnDate)*
        +CheckOut(memberId, today)
        +CheckIn()
    }
    LibraryItem <|-- Book : 5,000 VND per late day
    LibraryItem <|-- Magazine : 50,000 VND flat fee
    LibraryItem <|-- DigitalMedia : no fee, access revoked
    Library o-- LibraryItem
    Library o-- Member
```

- **Abstraction / inheritance:** `LibraryItem` is abstract; `Book`, `Magazine`, `DigitalMedia` extend it.
- **Polymorphism:** `Library.CheckIn` calls `item.CalculateLateFee(...)` without knowing the item type.
- **Encapsulation:** loan state and fines have private setters and only change through methods that validate.

Data is kept in memory and reset on every start.
