using System.Collections.Generic;

namespace CityLibrary.MVC.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}