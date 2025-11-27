class Stats
{
    public string Title;
    public int Year;
    public bool IsBorrowed; 
    
    public Stats()
    {
        Title = string.Empty; 
    }
}

class StateLibrary
{
    public Stats Book;
    public Stats Book1;
    public Stats Book2;
    public Stats Book3;
    public Stats Book4;
}

class Program
{
    static void Main(string[] args)
    {
        var state = new StateLibrary();
        
        state.Book = new Stats
        {
            Title = "Война и мир",
            Year = 1869,
            IsBorrowed = false,
        };
        state.Book1 = new Stats
        {
            Title = "Мастер и Маргарита",
            Year = 1967,
            IsBorrowed = false,
        };
        state.Book2 = new Stats
        {
            Title = "1984",
            Year = 1949,
            IsBorrowed = false,
        };
        state.Book3 = new Stats
        {
            Title = "Гордость и предубеждение",
            Year = 1813,
            IsBorrowed = false,
        };
        state.Book4 = new Stats
        {
            Title = "Гарри Поттер и Философский камень",
            Year = 1997,
            IsBorrowed = false,
        };

        Console.WriteLine("ИСХОДНОЕ СОСТОЯНИЕ");
        DisplayBookStatus(state.Book2);
        DisplayBookStatus(state.Book4); 

        Console.WriteLine("\nОПЕРАЦИЯ: Взять книгу '1984' ");
        
        if (!state.Book2.IsBorrowed) 
        {
            state.Book2.IsBorrowed = true; 
            Console.WriteLine($"УСПЕХ: Книга '{state.Book2.Title}' взята.");
        }
        else
        {
            Console.WriteLine($"ОШИБКА: Книга '{state.Book2.Title}' уже взята.");
        }
        
        Console.WriteLine("\nПРОМЕЖУТОЧНОЕ СОСТОЯНИЕ");
        DisplayBookStatus(state.Book2);
        
        Console.WriteLine("\nОПЕРАЦИЯ: Вернуть книгу '1984'");
        
        if (state.Book2.IsBorrowed) 
        {
            state.Book2.IsBorrowed = false; 
            Console.WriteLine($"УСПЕХ: Книга '{state.Book2.Title}' возвращена.");
        }
        else 
        {
            Console.WriteLine($"ОШИБКА: Книга '{state.Book2.Title}' не была взята.");
        }

        Console.WriteLine("\nФИНАЛЬНОЕ СОСТОЯНИЕ");
        DisplayBookStatus(state.Book2);
    }
    
    static void DisplayBookStatus(Stats book)
    {
        string status = book.IsBorrowed ? "Взята" : "Доступна";
        Console.WriteLine($"[{book.Title}] (Год: {book.Year}) — {status}");
    }
}