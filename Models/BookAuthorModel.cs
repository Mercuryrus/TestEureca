using System.Collections.Generic;

namespace TestEureca.Models
{

    public class BookAuthorModel
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int AuthorID { get; set; }
        //public List<AuthorModel> AuthorsID { get; } = new List<AuthorModel>();
        //public List<BookModel> BooksID { get; } = new List<BookModel>();
    }
}