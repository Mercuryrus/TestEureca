using System;
using System.Linq;
using TestEureca.Models;

namespace TestEureca
{
    public class Action
    {
        public Menu Menu = new Menu();
        public void AddBookAndAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите название книги:");
                string book = Console.ReadLine();
                Console.WriteLine("Введите автора:");
                string author = Console.ReadLine();
                if ((author == string.Empty) || (book == string.Empty))
                {
                    Console.WriteLine("Ошибка ввода");
                    AddBookAndAuthor();
                }
                BookModel addbook = new BookModel { Book = book };
                AuthorModel addauthor = new AuthorModel { Author = author };
                db.Authors.AddRange(addauthor);
                db.Books.AddRange(addbook);
                db.SaveChanges();
                int bookId = db.Books.OrderBy(x => x.ID).Last().ID;
                int authorId = db.Authors.OrderBy(x => x.ID).Last().ID;
                BookAuthorModel addAuthorBook = new BookAuthorModel { BookID = bookId, AuthorID = authorId };
                db.BookAuthor.AddRange(addAuthorBook);
                db.SaveChanges();
                Console.WriteLine("Запись добавлена");
            }
            Menu.AddMenu();
        }
        public void AddAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите автора:");
                string author = Console.ReadLine();
                if (author == string.Empty)
                {
                    Console.WriteLine("Ошибка ввода");
                    return;
                }
                AuthorModel addauthor = new AuthorModel { Author = author };
                db.Authors.AddRange(addauthor);
                db.SaveChanges();
                Console.WriteLine("Запись добавлена");
            }
            Menu.AddMenu();
        }
        public void AddBook()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите автора:");
                string book = Console.ReadLine();
                if (book == string.Empty)
                {
                    Console.WriteLine("Ошибка ввода");
                    return;
                }
                BookModel addbook = new BookModel { Book = book };
                db.Books.AddRange(addbook);
                db.SaveChanges();
                Console.WriteLine("Запись добавлена");
            }
            Menu.AddMenu();
        }
        public void ShowBookandAuthor()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var bookAuthorIDs = db.BookAuthor
                    .AsEnumerable()
                    .GroupBy(x => x.BookID)
                    .ToDictionary(x => x.Key, x => x.Select(y => y.AuthorID)
                    .ToList());
                foreach (var keyValue in bookAuthorIDs)
                {
                    Console.Write($"{db.Books.Single(x => x.ID == keyValue.Key).Book} - ");
                    foreach (var authorID in keyValue.Value)
                    {
                        Console.WriteLine($"{db.Authors.Single(x => x.ID == authorID).Author}\n");
                    }
                }
            }
            Menu.AddMenu();
        }
        public void ShowAuthors()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (AuthorModel id in db.Authors)
                {
                    Console.WriteLine($"{id.ID}.{id.Author}\n");
                }
            }
            Menu.ShowMenu();
        }
        public void ShowBooks()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (BookModel id in db.Books)
                {
                    Console.WriteLine($"{id.ID}.{id.Book}\n");
                }
            }
            Menu.ShowMenu();
        }
        public void EditBook()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\nВведите ID книги для редактирования");
                int id = int.Parse(Console.ReadLine());
                foreach (var book in db.Books)
                    if (id != book.ID)
                    {
                        Console.WriteLine($"Книга с ID({id}) не найдена");
                        return;
                    }
                BookModel ID = db.Books.Where(x => x.ID == id).FirstOrDefault();
                Console.WriteLine("Введите новое название книги");
                ID.Book = Console.ReadLine();
                db.Books.Update(ID);    
                db.SaveChanges();
            }
            ShowBooks();
        }
        public void EditAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\nВведите ID автора для редактирования");
                int id = int.Parse(Console.ReadLine());
                foreach (var author in db.Authors)
                    if (id != author.ID)
                    {
                        Console.WriteLine($"Автор с ID({id}) не найден");
                        return;
                    }
                AuthorModel ID = db.Authors.Where(x => x.ID == id).FirstOrDefault();
                Console.WriteLine("Введите новое имя автора");
                ID.Author = Console.ReadLine();
                db.Authors.Update(ID);
                db.SaveChanges();
            }
            ShowBooks();
        }
        public void RemoveBookAndAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\nВведите ID для для удаления");
                int id = int.Parse(Console.ReadLine());
                foreach (var bookAuthor in db.BookAuthor)
                {
                    if(bookAuthor.ID != id)
                    {
                        Console.WriteLine($"ID({id}) не найден");
                        return;
                    }
                }
                BookAuthorModel ID = db.BookAuthor.Where(x => x.ID == id).FirstOrDefault();
                db.BookAuthor.RemoveRange(ID);
                db.BookAuthor.Update(ID);
                db.SaveChanges();
            }
            ShowBooks();
        }
        public void RemoveBook()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.Clear();
                ShowBooks();
                Console.WriteLine("\nВведите ID книги для удаления");
                int id = int.Parse(Console.ReadLine());
                foreach (var book in db.Books)
                {
                    if (book.ID != id)
                    {
                        Console.WriteLine($"ID({id}) не найден");
                        return;
                    }
                }
                BookModel ID = db.Books.Where(x => x.ID == id).FirstOrDefault();
                db.Books.RemoveRange(ID);
                db.Books.Update(ID);
                db.SaveChanges();
            }
            Menu.RemoveMenu();
        }
        public void RemoveAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.Clear();
                ShowAuthors();
                Console.WriteLine("\nВведите ID автора для удаления");
                int id = int.Parse(Console.ReadLine());
                foreach (var author in db.Authors)
                {
                    if (author.ID != id)
                    {
                        Console.WriteLine($"ID({id}) не найден");
                        return;
                    }
                }
                AuthorModel ID = db.Authors.Where(x => x.ID == id).FirstOrDefault();
                db.Authors.RemoveRange(ID);
                db.Authors.Update(ID);
                db.SaveChanges();
            }
            Menu.RemoveMenu();
        }
    }
}
