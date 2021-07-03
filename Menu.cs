using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEureca
{
    public class Menu
    {

        public bool MainMenu()
        {
            Action Act = new Action();
            Console.Clear();
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1) Добавить книгу");
            Console.WriteLine("2) Добавить автора");
            Console.WriteLine("3) Показать список книг");
            Console.WriteLine("4) Удалить книгу");
            Console.WriteLine("5) Удалить автора");
            Console.WriteLine("0) Выход");
            Console.Write("\r\nВыберите вариант: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Act.AddBook();
                    return true;
                case "2":
                    Act.AddAuthor();
                    return true;
                case "3":
                    Act.ShowBook();
                    return true;
                case "4":
                    Act.RemoveBook();
                    return true;
                case "5":
                    Act.RemoveAuthor();
                    return true;
                case "0":
                    return false;
                default:
                    MainMenu();
                    return true;
            }
        }
        public bool AddMenu()
        {
            Action Act = new Action();
            Console.WriteLine("Меню:");
            Console.WriteLine("1) Добавить еще книгу");
            Console.WriteLine("2) В главное меню");
            Console.WriteLine("0) Выход");
            Console.Write("\r\nВыберите вариант: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Act.AddBook();
                    return true;
                case "2":
                    MainMenu();
                    return true;
                default:
                    AddMenu();
                    return true;
            }
        }
        public bool RemoveMenu()
        {
            Action Act = new Action();
            Console.WriteLine("Меню:");
            Console.WriteLine("1) Удалить еще одну книгу");
            Console.WriteLine("2) В главное меню");
            Console.WriteLine("0) Выход");
            Console.Write("\r\nВыберите вариант: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Act.RemoveBook();
                    return true;
                case "2":
                    MainMenu();
                    return true;
                default:
                    RemoveMenu();
                    return true;
            }
        }
        public bool ShowMenu()
        {
            Action Act = new Action();
            Console.WriteLine("Меню:");
            Console.WriteLine("1) В главное меню");
            Console.WriteLine("2) Изменить названия книги");
            Console.WriteLine("3) Изменить автора");
            Console.WriteLine("4) Книги автора");
            Console.WriteLine("0) Выход");
            Console.Write("\r\nВыберите вариант: ");

            switch (Console.ReadLine())
            {
                case "1":
                    MainMenu();
                    return true;
                case "2":
                    Act.EditBookName();
                    return true;
                case "3":
                    Act.EditBookAuthor();
                    return true;
                case "4":
                    Act.ShowAuthorBook();
                    return true;
                case "0":
                    return false;
                default:
                    ShowMenu();
                    return true;
            }
        }
    }
}
