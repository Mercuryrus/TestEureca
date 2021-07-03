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
                    return;
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
                string author= Console.ReadLine();
                if(author==string.Empty)
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
                    foreach(var authorID in keyValue.Value)
                    {
                        Console.WriteLine($"{db.Authors.Single(x => x.ID == authorID).Author}\n");
                    }
                }
            }
            Menu.ShowMenu();
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
        public void EditBookName()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите ID для редактирования");
                int id = int.Parse(Console.ReadLine());
                BookModel ID = db.Books.Where(x => x.ID == id).FirstOrDefault();
                Console.WriteLine("Введите новое название книги"); 
                ID.Book = Console.ReadLine();
                db.SaveChanges();
            }
            ShowBooks();
        }
        public void EditBookAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите ID для редактирования");
                int id = int.Parse(Console.ReadLine());
                BookAuthorModel ID = db.BookAuthor.Where(x => x.ID == id).FirstOrDefault();
                Console.WriteLine("Введите id автора");
                ID.AuthorID = int.Parse(Console.ReadLine());
                db.SaveChanges();
            }
            ShowBooks();
        }
        public void RemoveBook()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите ID для удаления");
                int id = int.Parse(Console.ReadLine());
                BookModel ID = db.Books.Where(x => x.ID == id).FirstOrDefault();
                db.Books.RemoveRange(ID);
                //Console.WriteLine("Нет книги с данным ID");
                db.SaveChanges();
            }
            Menu.RemoveMenu();
        }
        public void RemoveAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите ID для удаления");
                int id = int.Parse(Console.ReadLine());
                AuthorModel ID = db.Authors.Where(x => x.ID == id).FirstOrDefault();
                db.Authors.RemoveRange(ID);
                //Console.WriteLine("Нет Автора с данным ID");
                db.SaveChanges();
            }
            Menu.RemoveMenu();
        }
        public void ShowAuthorBooks()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите ID автора");
                int author = int.Parse(Console.ReadLine());
                var books = db.BookAuthor.Where(x=>x.AuthorID == author).ToList();
                Console.WriteLine($"Books {author} list:");
                foreach (BookAuthorModel str in books)
                {
                    Console.WriteLine($"{str.ID}.{str.BookID} - {str.AuthorID}");
                }
            }
            Menu.ShowMenu();
        }
    }
}
