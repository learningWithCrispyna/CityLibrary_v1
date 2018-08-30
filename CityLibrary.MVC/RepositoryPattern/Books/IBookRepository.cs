using CityLibrary.MVC.Models;
using System.Collections.Generic;

namespace CityLibrary.MVC.RepositoryPattern
{
    public interface IBookRepository : IRepository<Book>
    {
        IList<Book> GetFullNamesOfBooks();
    }
}