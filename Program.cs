using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace TestEureca
{
    public class Program
    {
        public static void Main()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // סמחהאול הגא מבתוךעא User
                Books user1 = new Books { ID = 1, Book = "Tom", Author = "Tooooooo" };
                Books user2 = new Books { ID = 2, Book = "Alice", Author = "JEEEEEEeee, Liasss" };

                // המבאגכÿול טץ ג בה
                db.Books.AddRange(user1, user2);
                db.SaveChanges();
            }
            // ןמכףקוםטו האםםûץ
            using (ApplicationContext db = new ApplicationContext())
            {
                // ןמכףקאול מבתוךעû טח בה ט גûגמהטל םא ךמםסמכü
                var books = db.Books.ToList();
                Console.WriteLine("Books list:");
                foreach (Books u in books)
                {
                    Console.WriteLine($"{u.ID}.{u.Book} - {u.Author}");
                }
            }
        }
    }
}