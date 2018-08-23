using System.Collections.Generic;

namespace CityLibrary.MVC.Models
{
    public class Author : Entity
    {
        public string AuthorName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}