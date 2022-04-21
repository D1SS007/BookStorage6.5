using System;
using System.Collections.Generic;

namespace BookStorage6._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookStoge bookStoge = new BookStoge();
            bookStoge.Work();
        }
    }

    class BookStoge
    {
        public List<Book> _books = new List<Book>();

        private bool _isWorking = true;

        public BookStoge()
        {
            _books.Add(new Book("Евгений Онегин", "Пушкин", 1830));
            _books.Add(new Book("Мернтвые души", "Гоголь", 1842));
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

                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddBook();
                        break;

                    case 2:
                        RemoveBook();
                        break;

                    case 3:
                        ShowAllBooks();
                        break;

                    case 4:
                        FindBookByParametrs();
                        break;

                    case 5:
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
            Console.WriteLine("Введите год написания книги");
            bool succsessfullyConverted = CanNumberBeConverted(out int bookYear);

            if (succsessfullyConverted)
            {
                if(bookYear > int.MinValue && bookYear < int.MaxValue)
                {
                    _books.Add(new Book(userInputBookName,userInputBookAuthor,bookYear));
                    Console.WriteLine("Книга успешно добавлена");
                    PrintPlugMassage();
                }
                else
                {
                    PrintPlugNegativeMassage();
                }
            }
            else
            {
                PrintPlugNegativeMassage();
            }
        }

        private void RemoveBook()
        {
            ShowAllBooks();
            Console.WriteLine("Введите индекс книги");
            bool succsessfullyConverted = CanNumberBeConverted(out int result);

            if (succsessfullyConverted)
            {
                if(result >= 1 && result <= _books.Count)
                {
                    _books.RemoveAt(result - 1);
                    Console.WriteLine("Книга успешно удалена");
                    PrintPlugMassage();
                }
                else
                {
                    PrintPlugNegativeMassage();
                }
            }
            else
            {
                PrintPlugNegativeMassage();
            }
        }

        private void FindBookByParametrs()
        {
            Console.WriteLine("1 - Поиск по названию\n2 - Поиск по фамилии\n3 - Поиск по году публикации\n4 - Назад");

            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    FindByBookName();
                    break;

                case 2:
                    FindByAuthor();
                    break;

                case 3:
                    FindByYear();
                    break;

                case 4:
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Такой функции нет");
                    break;
            }
        }

        private void FindByBookName()
        {
            Console.Write("Введите название книги");
            string nameOfBook = Console.ReadLine();

            foreach (var book in _books)
            {
                if (nameOfBook.ToLower() == book.Name.ToLower())
                {
                    Console.WriteLine($" {book.Name} {book.Author} {book.Year}");
                }
                else
                {
                    PrintPlugNegativeMassage();
                }
            }
        }

        private void FindByAuthor()
        {
            Console.Write("Введите фамилию автора");
            string authorOfBook = Console.ReadLine();

            foreach (var book in _books)
            {
                if (authorOfBook.ToLower() == book.Author.ToLower())
                {
                    Console.WriteLine($"{book.Name} {book.Author} {book.Year}");
                }
                else
                {
                    PrintPlugNegativeMassage();
                }
            }
        }

        private void FindByYear()
        {
            Console.Write("Введите год публикации");
            bool succsessfullyConverted = CanNumberBeConverted(out int bookYearOfRelease);

            if (succsessfullyConverted)
            {
                if (bookYearOfRelease > int.MinValue && bookYearOfRelease < int.MaxValue)
                {
                    foreach(var book in _books)
                    {
                        if(bookYearOfRelease == book.Year)
                        {
                            Console.WriteLine($"{book.Name} {book.Author} {book.Year}");
                        }
                        else
                        {
                            PrintPlugNegativeMassage();
                        }
                    }
                }
                else
                {
                    PrintPlugNegativeMassage();
                }
            }
            else
            {
                PrintPlugNegativeMassage();
            }
        }

        private void ShowAllBooks()
        {
            if (_books.Count > 0)
            {

                for (int i = 0; i < _books.Count; i++)
                {
                    Console.Write($"(i + 1) - ");
                    _books[i].ShowBookInfo();
                }
            }            
            else
            {
                Console.WriteLine("В базе нет игроков");
                PrintPlugMassage();
            }
        }

        private bool CanNumberBeConverted(out int result)
        {
            string userInput = Console.ReadLine();
            bool sucsessfullyConverted = int.TryParse(userInput, out result);
            return sucsessfullyConverted;
        }

        private void PrintPlugMassage()
        {
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.ReadKey();
            Console.Clear();
        }

        private void PrintPlugNegativeMassage()
        {
            Console.WriteLine("Некорректные данные\nНажмите любую кнопку для продолжения");
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

        public void ShowBookInfo()
        {
            Console.WriteLine($"{Name} {Author} {Year}");
        }

    }
}
