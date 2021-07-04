using System;
using System.Data.Entity;
using System.Linq;
using TestEureca.Models;

namespace TestEureca
{
    public class Action
    {
        public Menu Menu = new Menu();
        public void AddBookAndAuthor()//rdy
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
                    Menu.MainMenu();
                }
                else if (db.Books.Any(x => x.Book == book)) 
                {
                    Console.WriteLine("Книга с таким названием уже существует");
                    int newIDbook = db.Books.OrderBy(x => x.ID).Last(x => x.Book == book).ID;
                    int newIDauthor = db.Authors.OrderBy(x => x.ID).Last().ID;
                    BookAuthorModel addAuthor = new BookAuthorModel { BookID = newIDbook, AuthorID = newIDauthor };
                    db.BookAuthor.AddRange(addAuthor);
                    db.SaveChanges();
                    Console.WriteLine("Запись добавлена");
                }
                else if(db.Authors.Any(x=>x.Author == author))
                {
                    Console.WriteLine("Автор с таким именем уже существует");
                    BookModel addbook = new BookModel { Book = book };
                    db.Books.AddRange(addbook);
                    db.SaveChanges();
                    int newIDauthor = db.Authors.OrderBy(x => x.ID).Last(x => x.Author == author).ID;
                    int newIDbook = db.Books.OrderBy(x => x.ID).Last().ID;
                    BookAuthorModel addBook = new BookAuthorModel { BookID = newIDbook, AuthorID = newIDauthor };
                    db.BookAuthor.AddRange(addBook);
                    db.SaveChanges();
                    Console.WriteLine("Запись добавлена");
                }
                else
                {
                    AuthorModel addauthor = new AuthorModel { Author = author };
                    BookModel addbook = new BookModel { Book = book };
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
            }
            Console.ReadLine();
            Menu.MainMenu();
        }
        public void AddAuthor()//rdy
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите автора:");
                string author = Console.ReadLine();
                if (author == string.Empty)
                {
                    Console.WriteLine("Ошибка ввода");
                    Menu.MainMenu();
                }
                else if(db.Authors.Any(x => x.Author == author))
                {
                    Console.WriteLine("Автор с таким именем существует");
                }
                else
                {
                    AuthorModel addauthor = new AuthorModel { Author = author };
                    db.Authors.AddRange(addauthor);
                    db.SaveChanges();
                    Console.WriteLine("Запись добавлена");
                }
                
            }
            Console.ReadLine();
            Menu.MainMenu();
        }
        public void AddBook()//rdy
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите название книги:");
                string book = Console.ReadLine();
                if (book == string.Empty)
                {
                    Console.WriteLine("Ошибка ввода");
                    Menu.MainMenu();
                }
                else if (db.Books.Any(x => x.Book == book))
                {
                    Console.WriteLine("Книга с таким именем существует");

                }
                else
                {
                    BookModel addbook = new BookModel { Book = book };
                    db.Books.AddRange(addbook);
                    db.SaveChanges();
                    Console.WriteLine("Запись добавлена");
                }
            }
            Console.ReadLine();
            Menu.MainMenu();
        }
        public void ShowBookAndAuthor()//rdy
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var bookAuthorIDs = db.BookAuthor.AsEnumerable()
                                                 .GroupBy(x => x.BookID)
                                                 .ToDictionary(x => x.Key, x => x.Select(y => y.AuthorID)
                                                 .ToList());
                foreach (var keyValue in bookAuthorIDs)
                {
                    Console.Write($"{db.BookAuthor.OrderBy(x=>x.ID).Last(x=>x.BookID == keyValue.Key).ID}) {db.Books.Single(x => x.ID == keyValue.Key).Book} -");
                    foreach (var authorID in keyValue.Value)
                    {
                        Console.Write($" {db.Authors.Single(x => x.ID == authorID).Author},");
                    }
                    Console.WriteLine("\n");
                }
            }
            Console.ReadLine();
            Menu.MainMenu();
        }
        public void ShowAuthors()//rdy
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (AuthorModel id in db.Authors.OrderBy(x => x.ID))
                {
                    Console.WriteLine($"{id.ID}.{id.Author}\n");
                }
            }
            Console.ReadLine();
            Menu.MainMenu();
        }
        public void ShowBooks()//rdy
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (BookModel id in db.Books.OrderBy(x=>x.ID))
                {
                    Console.WriteLine($"{id.ID}.{id.Book}\n");
                }
            }
            Console.ReadLine();
            Menu.MainMenu();
        }
        public void EditBook()//rdy
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\nВведите ID книги для редактирования");
                int id = int.Parse(Console.ReadLine());
                if (db.Books.Any(x => x.ID == id))
                {
                    BookModel bookID = db.Books.Single(x => x.ID == id);
                    Console.WriteLine("Введите новое название книги");
                    bookID.Book = Console.ReadLine();
                    db.Books.Update(bookID);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Книги с ID{id} не существует");
                }
            }
            ShowBooks();
        }
        public void EditAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\nВведите ID автора для редактирования");
                int id = int.Parse(Console.ReadLine());
                if (db.Authors.Any(x => x.ID == id))
                {
                    AuthorModel authorID = db.Authors.Single(x => x.ID == id);
                    Console.WriteLine("Введите новое имя автора");
                    authorID.Author = Console.ReadLine();
                    db.Authors.Update(authorID);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Автора с ID{id} не существует");
                }
            }
            ShowAuthors();
        }
        public void RemoveBookAndAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\nВведите ID для для удаления");
                int id = int.Parse(Console.ReadLine());
                if (db.BookAuthor.OrderBy(x => x.ID).Any(x => x.ID == id))
                {
                    BookAuthorModel bookAuthorID = db.BookAuthor.OrderBy(x => x.ID).Last(x => x.ID == id);
                    db.BookAuthor.RemoveRange(bookAuthorID);
                    db.SaveChanges();
                }
            }
            ShowBookAndAuthor();
        }
        public void RemoveBook()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\nВведите ID книги для удаления");
                int id = int.Parse(Console.ReadLine());
                  
                BookModel bookID = db.Books.OrderBy(x => x.ID).Last(x => x.ID == id);
                db.Books.RemoveRange(bookID);
                if (db.BookAuthor.OrderBy(x=>x.ID).Any(x=>x.BookID == bookID.ID))
                {
                    BookAuthorModel bookAuthorID = db.BookAuthor.OrderBy(x => x.ID).Where(x => x.BookID == bookID.ID).Last();
                    db.BookAuthor.RemoveRange(bookAuthorID); 
                }
                db.SaveChanges();                
            }
            Console.ReadLine();
            Menu.MainMenu();
        }
        public void RemoveAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\nВведите ID автора для удаления");
                int id = int.Parse(Console.ReadLine());
                AuthorModel authorID = db.Authors.OrderBy(x=>x.ID).Last(x => x.ID == id);
                db.Authors.RemoveRange(authorID);
                if (db.BookAuthor.OrderBy(x => x.ID).Any(x => x.AuthorID == authorID.ID))
                {
                    BookAuthorModel bookAuthorID = db.BookAuthor.OrderBy(x => x.ID).Where(x => x.AuthorID == authorID.ID).Last();
                    db.BookAuthor.RemoveRange(bookAuthorID);
                }
                db.SaveChanges();
            }
            Console.ReadLine();
            Menu.MainMenu();
        }
    }
}
