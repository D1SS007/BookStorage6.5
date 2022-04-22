using System;
using System.Collections.Generic;

namespace BookStorage6._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookStorage bookStorage = new BookStorage();
            bookStorage.Work();
        }
    }

    class BookStorage
    {
        public List<Book> _books = new List<Book>();

        private bool _isWorking = true;

        public BookStorage()
        {
            _books.Add(new Book("Евгений Онегин", "Пушкин", 1830));
            _books.Add(new Book("Мертвые души", "Гоголь", 1842));
            _books.Add(new Book("Герой нашего времени", "Лермонтов", 1840));
            _books.Add(new Book("Преступление и наказание", "Достоевский", 1830));
            _books.Add(new Book("Горе от ума", "Грибоедов", 1866));
            _books.Add(new Book("метро 2033", "Глуховский", 2005));            
        }

        public void Work()
        {
            while (_isWorking)
            {
                Console.WriteLine("1 - Добавить книгу\n2 - Убрать книгу из хранилища\n3 - Показать все книги\n4 - Поиск по параметру\n5 - Выход");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBook();
                        break;

                    case "2":
                        RemoveBook();
                        break;

                    case "3":
                        ShowAllBooks();
                        break;

                    case "4":
                        FindBookByParametrs();
                        break;

                    case "5":
                        _isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Такой функции нет");
                        break;                        
                }
            }
        }

        private void AddBook()
        {
            Console.WriteLine("Ведите название книги");
            string userInputBookName = Console.ReadLine();
            Console.WriteLine("Ведите фамилию автора книги");
            string userInputBookAuthor = Console.ReadLine();
            Console.WriteLine("Введите год публикации книги");            

            if (int.TryParse(Console.ReadLine(), out int bookYear))
            {
                _books.Add(new Book(userInputBookName, userInputBookAuthor, bookYear));                
                PrintPlugMassage("\nКнига успешно добавлена");
            }
            else
            {
                PrintPlugMassage("Некорректные данны\nНажмите кнопку для продолжения");
            }
        }

        private void RemoveBook()
        {
            ShowAllBooks();
            Console.WriteLine("\nВведите порядковый номер книги которую хотите удалить");            

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if(result >= 1 && result <= _books.Count)
                {
                    _books.RemoveAt(result - 1);                    
                    PrintPlugMassage("Книга успешно удалена");
                }
                else
                {
                    PrintPlugMassage("Некорректные данны\nНажмите кнопку для продолжения");
                }
            }
            else
            {
                PrintPlugMassage("Некорректные данны\nНажмите кнопку для продолжения");
            }
        }

        private void FindBookByParametrs()
        {
            Console.WriteLine("1 - Поиск по названию\n2 - Поиск по фамилии\n3 - Поиск по году публикации\n4 - Назад");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    FindByBookName();
                    break;

                case "2":
                    FindByAuthor();
                    break;

                case "3":
                    FindByYear();
                    break;

                case "4":
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Такой функции нет");
                    break;
            }
        }

        private void FindByBookName()
        {
            bool isBookFoundByName = false;
            Console.WriteLine("Введите название книги");
            string nameOfBook = Console.ReadLine();

            foreach (var book in _books)
            {
                if (nameOfBook.ToLower() == book.Name.ToLower())
                {
                    ShowFoundBook(book);
                    isBookFoundByName = true;
                    
                }                
            }
            if(isBookFoundByName == false)
            {
                PrintPlugMassage("Некорректные данны\nНажмите кнопку для продолжения");
            }
            PrintPlugMassage("Нажмите кнопку для продолжения");
        }

        private void FindByAuthor()
        {
            bool isBookFoundByAuthor = false;
            Console.WriteLine("Введите фамилию автора");
            string authorOfBook = Console.ReadLine();

            foreach (var book in _books)
            {
                if (authorOfBook.ToLower() == book.Author.ToLower())
                {
                    ShowFoundBook(book);
                    isBookFoundByAuthor = true;                    
                }                
            }
            if (isBookFoundByAuthor == false)
            {
                PrintPlugMassage("Некорректные данны\nНажмите кнопку для продолжения");
            }
            PrintPlugMassage("Нажмите кнопку для продолжения");
        }

        private void FindByYear()
        {
            bool isBookFoundByYear = false;
            Console.WriteLine("Введите год публикации");            

            if (int.TryParse(Console.ReadLine(), out int bookYearOfRelease))
            {
                foreach (Book book in _books)
                {
                    if (bookYearOfRelease == book.Year)
                    {
                        ShowFoundBook(book);
                        isBookFoundByYear=true;                        
                    }                    
                }
                if(isBookFoundByYear == false)
                {
                    PrintPlugMassage("Некорректные данны\nНажмите кнопку для продолжения");
                }
            }
            else
            {
                PrintPlugMassage("Некорректные данны\nНажмите кнопку для продолжения");
            }
            PrintPlugMassage("Нажмите кнопку для продолжения");
        }

        private void ShowFoundBook(Book book)
        {            
            Console.WriteLine($"{book.Name} {book.Author} {book.Year}");
        }

        private void ShowAllBooks()
        {
            if (_books.Count > 0)
            {

                for (int i = 0; i < _books.Count; i++)
                {
                    Console.Write($"{i + 1} - ");
                    _books[i].ShowInfo();
                }                
            }            
            else
            {                
                PrintPlugMassage("На полке нет книг\nНажмите кнопку для продолжения");
            }
        }

        private void PrintPlugMassage(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Clear();
        }        
    }

    class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }

        public Book( string name, string author, int year)
        {
            Name = name;
            Author = author;
            Year = year;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} {Author} {Year}");
        }
    }
}
