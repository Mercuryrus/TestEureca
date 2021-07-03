using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEureca.Models;

namespace TestEureca
{
    public class Action
    {
        public Menu Menu = new Menu();
        public void AddBook()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите название книги:");
                string book = Console.ReadLine();
                BookModel addbook = new BookModel { Books = book };
                db.Book.AddRange(addbook);
                db.SaveChanges();
            }
            Menu.AddMenu();
        }
        public void AddAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите автора:");
                string author= Console.ReadLine();
                AuthorModel addauthor = new AuthorModel { Authors = author };
                db.Author.AddRange(addauthor);
                db.SaveChanges();
            }
            Menu.AddMenu();
        }
        public void ShowBook()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (BookAuthorModel id in db.Books)
                {
                    int bookID = Convert.ToInt32(db.Book.Where(x => x.IDBooks == id.BookID));
                    int authorID = Convert.ToInt32(db.Books.Select(x => x.AuthorID));
                    BookModel book = db.Book.Where(x => x.IDBooks == bookID).FirstOrDefault();
                    AuthorModel author = db.Author.Where(x => x.IDAuthors == authorID).FirstOrDefault();
                    Console.WriteLine($"{id.ID}. {book} - {author}");
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
                BookModel ID = db.Book.Where(x => x.IDBooks == id).FirstOrDefault();
                Console.WriteLine("Введите новое название книги"); 
                ID.Books = Console.ReadLine();
                db.SaveChanges();
            }
            ShowBook();
        }
        public void EditBookAuthor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите ID для редактирования");
                int id = int.Parse(Console.ReadLine());
                BookAuthorModel ID = db.Books.Where(x => x.ID == id).FirstOrDefault();
                Console.WriteLine("Введите id автора");
                ID.AuthorID = int.Parse(Console.ReadLine());
                db.SaveChanges();
            }
            ShowBook();
        }
        public void RemoveBook()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите ID для удаления");
                int id = int.Parse(Console.ReadLine());
                BookModel ID = db.Book.Where(x => x.IDBooks == id).FirstOrDefault();
                db.Book.RemoveRange(ID);
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
                AuthorModel ID = db.Author.Where(x => x.IDAuthors == id).FirstOrDefault();
                db.Author.RemoveRange(ID);
                //Console.WriteLine("Нет Автора с данным ID");
                db.SaveChanges();
            }
            Menu.RemoveMenu();
        }
        public void ShowAuthorBook()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите ID автора");
                int author = int.Parse(Console.ReadLine());
                var books = db.Books.Where(x=>x.AuthorID == author).ToList();
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
