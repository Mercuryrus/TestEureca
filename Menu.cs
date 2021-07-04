using System;


namespace TestEureca
{
    public class Menu
    {

        public bool MainMenu()
        {
            Action Act = new Action();
            Console.Clear();
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1) Добавить книгу и автора");
            Console.WriteLine("2) Добавить автора");
            Console.WriteLine("3) Добавить книгу");
            Console.WriteLine("4) Показать список книг и авторов");
            Console.WriteLine("5) Показать список книг");
            Console.WriteLine("6) Показать список авторов");
            Console.WriteLine("7) Удалить книгу");
            Console.WriteLine("8) Удалить автора");
            Console.WriteLine("9) Удалить книгу и автора");
            Console.WriteLine("10) Изменить название книги");
            Console.WriteLine("11) Изменить имя автора");
            Console.WriteLine("0) Выход");
            Console.Write("\r\nВыберите вариант: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Act.AddBookAndAuthor();
                    return true;
                case "2":
                    Act.AddAuthor();
                    return true;
                case "3":
                    Act.AddBook();
                    return true;
                case "4":
                    Act.ShowBookAndAuthor();
                    return true;
                case "5":
                    Act.ShowBooks();
                    return true;
                case "6":
                    Act.ShowAuthors();
                    return true;
                case "7":
                    Act.RemoveBook();
                    return true;
                case "8":
                    Act.RemoveAuthor();
                    return true;
                case "9":
                    Act.RemoveBookAndAuthor();
                    return true;
                case "10":
                    Act.EditBook();
                    return true;
                case "11":
                    Act.EditAuthor();
                    return true;
                case "0":
                    return false;
                default:
                    MainMenu();
                    return true;
            }
        }
    }
}
