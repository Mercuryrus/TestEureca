using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                Console.WriteLine("Введите автора книги:");
                string author = Console.ReadLine();
                Books addbook = new Books { Book = book, Author = author };
                db.Books.AddRange(addbook);
                db.SaveChanges();
            }
            Menu.AddMenu();
        }
        public void ShowBook()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var books = db.Books.ToList();
                Console.WriteLine("Books list:");
                foreach (Books str in books)
                {
                    Console.WriteLine($"{str.ID}.{str.Book} - {str.Author}");
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
                Books ID = db.Books.Where(x => x.ID == id).FirstOrDefault();
                Console.WriteLine("Введите новое название книги"); 
                ID.Book = Console.ReadLine();
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
                Books ID = db.Books.Where(x => x.ID == id).FirstOrDefault();
                Console.WriteLine("Введите автора");
                ID.Author = Console.ReadLine();
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
                Books ID = db.Books.Where(x => x.ID == id).FirstOrDefault();
                db.Books.RemoveRange(ID);
                //Console.WriteLine("Нет книги с данным ID");
                db.SaveChanges();
            }
            Menu.RemoveMenu();
        }
    }
}
