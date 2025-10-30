using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    // Класс Книга
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public Book(int id, string title, string author, int year, string isbn)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
            IsAvailable = true;
        }

        public override string ToString()
        {
            string status = IsAvailable ? "Доступна" : "Выдана";
            return $"ID: {Id} | {Title} - {Author} ({Year}) | ISBN: {ISBN} | {status}";
        }
    }

    // Класс Библиотека
    public class Library
    {
        private List<Book> books;
        private int nextId;

        public Library()
        {
            books = new List<Book>();
            nextId = 1;

            // Добавляем несколько тестовых книг
            AddTestData();
        }

        private void AddTestData()
        {
            books.Add(new Book(nextId++, "Преступление и наказание", "Федор Достоевский", 1866, "978-5-699-12345-0"));
            books.Add(new Book(nextId++, "Мастер и Маргарита", "Михаил Булгаков", 1967, "978-5-389-06767-9"));
            books.Add(new Book(nextId++, "1984", "Джордж Оруэлл", 1949, "978-5-17-087855-6"));
        }

        public void AddBook()
        {
            Console.WriteLine("\n--- Добавление новой книги ---");

            Console.Write("Введите название: ");
            string title = Console.ReadLine();

            Console.Write("Введите автора: ");
            string author = Console.ReadLine();

            Console.Write("Введите год издания: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Введите ISBN: ");
            string isbn = Console.ReadLine();

            Book newBook = new Book(nextId++, title, author, year, isbn);
            books.Add(newBook);

            Console.WriteLine($"Книга успешно добавлена! ID: {newBook.Id}");
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("\n--- Все книги в библиотеке ---");

            if (!books.Any())
            {
                Console.WriteLine("В библиотеке нет книг.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void SearchBook()
        {
            Console.WriteLine("\n--- Поиск книги ---");
            Console.WriteLine("1. По названию");
            Console.WriteLine("2. По автору");
            Console.WriteLine("3. По ISBN");
            Console.Write("Выберите тип поиска: ");

            string searchType = Console.ReadLine();
            Console.Write("Введите поисковый запрос: ");
            string query = Console.ReadLine().ToLower();

            List<Book> results = new List<Book>();

            switch (searchType)
            {
                case "1":
                    results = books.Where(b => b.Title.ToLower().Contains(query)).ToList();
                    break;
                case "2":
                    results = books.Where(b => b.Author.ToLower().Contains(query)).ToList();
                    break;
                case "3":
                    results = books.Where(b => b.ISBN.ToLower().Contains(query)).ToList();
                    break;
                default:
                    Console.WriteLine("Неверный тип поиска!");
                    return;
            }

            if (results.Any())
            {
                Console.WriteLine($"\nНайдено книг: {results.Count}");
                foreach (var book in results)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("Книги не найдены.");
            }
        }

        public void DeleteBook()
        {
            Console.WriteLine("\n--- Удаление книги ---");
            DisplayAllBooks();

            Console.Write("Введите ID книги для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Book bookToRemove = books.FirstOrDefault(b => b.Id == id);
                if (bookToRemove != null)
                {
                    books.Remove(bookToRemove);
                    Console.WriteLine("Книга успешно удалена!");
                }
                else
                {
                    Console.WriteLine("Книга с указанным ID не найдена.");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ID!");
            }
        }
    }

    // Главный класс программы
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== ИС БИБЛИОТЕКА ===");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Показать все книги");
                Console.WriteLine("3. Найти книгу");
                Console.WriteLine("4. Удалить книгу");
                Console.WriteLine("5. Выйти");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.AddBook();
                        break;
                    case "2":
                        library.DisplayAllBooks();
                        break;
                    case "3":
                        library.SearchBook();
                        break;
                    case "4":
                        library.DeleteBook();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("До свидания!");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }
    }
}