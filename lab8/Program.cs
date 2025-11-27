class Book
{
    public string Title;
    public int Year;
    public bool IsBorrowed; 
    
    public Book(string title, int year)
    {
        Title = title;
        Year = year;
        IsBorrowed = false;
    }
}

class LibraryState
{
    public Book[] Collection;
    
    public LibraryState()
    {
        Collection = new Book[]
        {
            new Book("Война и мир", 1869),
            new Book("Мастер и Маргарита", 1967),
            new Book("1984", 1949),
            new Book("Гордость и предубеждение", 1813),
            new Book("Гарри Поттер и Философский камень", 1997)
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        var state = new LibraryState();

        Console.WriteLine(" ИСХОДНОЕ СОСТОЯНИЕ ");
        DisplayAllBooks(state);

        Console.WriteLine("\n ОПЕРАЦИИ ВЗЯТИЯ КНИГИ ");
        BorrowBook(state, "1984"); 
        BorrowBook(state, "1984"); 
        BorrowBook(state, "Незнайка на Луне"); 
        
        Console.WriteLine("\n ПРОМЕЖУТОЧНОЕ СОСТОЯНИЕ ");
        DisplayAllBooks(state);

        Console.WriteLine("\n ОПЕРАЦИИ ВОЗВРАТА КНИГИ ");
        ReturnBook(state, "Автостопом по Галактике"); 
        ReturnBook(state, "Война и мир"); 
        ReturnBook(state, "1984"); 
        
        Console.WriteLine("\n ФИНАЛЬНОЕ СОСТОЯНИЕ ");
        DisplayAllBooks(state);
    }
    static int CountBooksAfter2000(LibraryState state){
        var count = 0;
        for(var i = 0; i < state.length; i++){
            if(year[i] >= 2000){
                count++;
            }
        }
        return count;

    }
    
    static void DisplayAllBooks(LibraryState state)
    {
        Console.WriteLine("Формат: Название Год — Статус");
        foreach (var book in state.Collection)
        {
            string status = book.IsBorrowed ? "Взята" : "Доступна";
            Console.WriteLine($"{book.Title} {book.Year} — {status}");
        }
    }

    static void BorrowBook(LibraryState state, string title)
    {
        foreach (var book in state.Collection)
        {
                if (!book.IsBorrowed)
                {
                    book.IsBorrowed = true;
                    Console.WriteLine($"УСПЕХ: Книга '{title}' взята.");
                    break;
                }
                if (book.IsBorrowed)
                {
                    book.IsBorrowed = false;
                    Console.WriteLine($"ОШИБКА: Книга '{title}' уже взята.");
                    break;
                }
            
        }
        Console.WriteLine($"ОШИБКА: Книга '{title}' не найдена в библиотеке.");
    }

    static void ReturnBook(LibraryState state, string title)
    {
        foreach (var book in state.Collection)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (book.IsBorrowed)
                {
                    book.IsBorrowed = false;
                    Console.WriteLine($"УСПЕХ: Книга '{title}' возвращена.");
                }
                else
                {
                    Console.WriteLine($"ОШИБКА: Книга '{title}' не была взята.");
                }
                return;
            }
        }
        Console.WriteLine($"ОШИБКА: Книга '{title}' не найдена в библиотеке.");
    }
}