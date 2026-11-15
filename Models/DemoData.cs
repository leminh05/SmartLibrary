namespace SmartLibrary;

// Realistic demo data: 50 real books, 40 fictional members, and loans dated relative to "today"
// so the overdue items stay overdue no matter when the demo runs.
public static class DemoData
{
    public static readonly string[] Books =
    {
        "Clean Code - Robert C. Martin",
        "Design Patterns - Erich Gamma et al.",
        "The Pragmatic Programmer - Andrew Hunt & David Thomas",
        "Refactoring - Martin Fowler",
        "Head First Design Patterns - Eric Freeman & Elisabeth Robson",
        "Code Complete - Steve McConnell",
        "Introduction to Algorithms - Thomas H. Cormen et al.",
        "The Mythical Man-Month - Frederick P. Brooks Jr.",
        "Effective Java - Joshua Bloch",
        "C# in Depth - Jon Skeet",
        "Clean Architecture - Robert C. Martin",
        "Domain-Driven Design - Eric Evans",
        "Working Effectively with Legacy Code - Michael Feathers",
        "Test-Driven Development: By Example - Kent Beck",
        "Structure and Interpretation of Computer Programs - Abelson & Sussman",
        "The C Programming Language - Kernighan & Ritchie",
        "Cracking the Coding Interview - Gayle Laakmann McDowell",
        "Grokking Algorithms - Aditya Bhargava",
        "Patterns of Enterprise Application Architecture - Martin Fowler",
        "Object-Oriented Software Construction - Bertrand Meyer",
        "Don't Make Me Think - Steve Krug",
        "The Clean Coder - Robert C. Martin",
        "Designing Data-Intensive Applications - Martin Kleppmann",
        "Computer Networking: A Top-Down Approach - Kurose & Ross",
        "Operating System Concepts - Abraham Silberschatz et al.",
        "Artificial Intelligence: A Modern Approach - Russell & Norvig",
        "Deep Learning - Ian Goodfellow et al.",
        "The Art of Computer Programming - Donald E. Knuth",
        "Sapiens - Yuval Noah Harari",
        "Atomic Habits - James Clear",
        "Dế Mèn Phiêu Lưu Ký - Tô Hoài",
        "Số Đỏ - Vũ Trọng Phụng",
        "Tắt Đèn - Ngô Tất Tố",
        "Truyện Kiều - Nguyễn Du",
        "Mắt Biếc - Nguyễn Nhật Ánh",
        "Cho Tôi Xin Một Vé Đi Tuổi Thơ - Nguyễn Nhật Ánh",
        "Nhà Giả Kim - Paulo Coelho",
        "Đắc Nhân Tâm - Dale Carnegie",
        "Harry Potter and the Philosopher's Stone - J.K. Rowling",
        "To Kill a Mockingbird - Harper Lee",
        "1984 - George Orwell",
        "Pride and Prejudice - Jane Austen",
        "The Great Gatsby - F. Scott Fitzgerald",
        "The Little Prince - Antoine de Saint-Exupéry",
        "The Hobbit - J.R.R. Tolkien",
        "Thinking, Fast and Slow - Daniel Kahneman",
        "The Lean Startup - Eric Ries",
        "Rich Dad Poor Dad - Robert T. Kiyosaki",
        "A Brief History of Time - Stephen Hawking",
        "The Alchemist (English Edition) - Paulo Coelho",
    };

    // Fictional people.
    public static readonly string[] Members =
    {
        "Nguyễn Văn An", "Trần Thị Bình", "Lê Hoàng Cường", "Phạm Thị Dung", "Hoàng Minh Đức",
        "Vũ Thị Hà", "Đặng Quốc Huy", "Bùi Thị Hương", "Đỗ Văn Khang", "Hồ Thị Lan",
        "Ngô Minh Long", "Dương Thị Mai", "Lý Văn Nam", "Phan Thị Ngọc", "Trịnh Quang Phúc",
        "Võ Thị Quỳnh", "Đinh Văn Sơn", "Mai Thị Thảo", "Lâm Đức Thắng", "Châu Thị Trang",
        "Nguyễn Hữu Tuấn", "Trần Thị Uyên", "Lê Văn Việt", "Phạm Thị Xuân", "Hoàng Thị Yến",
        "Vũ Đình Bảo", "Đặng Thị Chi", "Bùi Văn Danh", "Đỗ Thị Giang", "Hồ Minh Hiếu",
        "Ngô Thị Kim", "Dương Văn Lộc", "Lý Thị My", "Phan Văn Nghĩa", "Trịnh Thị Oanh",
        "Võ Văn Phát", "Đinh Thị Quyên", "Mai Văn Tài", "Lâm Thị Thu", "Châu Văn Vinh",
    };

    public static Library Create(DateTime today)
    {
        var lib = new Library();
        Library.AddDemoStaff(lib);

        for (int i = 0; i < Books.Length; i++)
            lib.AddItem(new Book($"B{i + 1:000}", Books[i]));
        lib.AddItem(new Magazine("M001", "National Geographic - November 2026"));
        lib.AddItem(new Magazine("M002", "Tạp chí Tin học & Đời sống - Số 45"));
        lib.AddItem(new Magazine("M003", "Time Magazine - Issue 18"));
        lib.AddItem(new DigitalMedia("D001", "C# Fundamentals (Video Course)"));
        lib.AddItem(new DigitalMedia("D002", "OOP in Practice (E-book)"));
        lib.AddItem(new DigitalMedia("D003", "Clean Code (Audiobook)"));

        for (int i = 0; i < Members.Length; i++)
            lib.AddMember($"S{i + 1:000}", Members[i]);

        // S001-S030 each borrow one book. Every 5th member borrowed long ago, so 6 books are overdue.
        for (int k = 1; k <= 30; k++)
        {
            int daysAgo = k % 5 == 0 ? 14 + k / 5 * 3 : k % 13;
            lib.CheckOut($"B{k:000}", $"S{k:000}", today.AddDays(-daysAgo));
        }

        // A second book for a few members, a late magazine and a late digital loan.
        lib.CheckOut("B040", "S001", today.AddDays(-2));
        lib.CheckOut("B041", "S002", today.AddDays(-4));
        lib.CheckOut("M001", "S031", today.AddDays(-10)); // 3 days late -> flat fee on return
        lib.CheckOut("D001", "S032", today.AddDays(-5));  // 2 days late -> access revoked on return

        // S033-S036 returned books late last month, so they owe fines (went through the normal CheckIn rules).
        for (int k = 33; k <= 36; k++)
        {
            lib.CheckOut($"B{k:000}", $"S{k:000}", today.AddDays(-40));
            lib.CheckIn($"B{k:000}", today.AddDays(-40 + 14 + (k - 30)));
        }

        // S037-S040 have no activity yet.
        return lib;
    }
}
