using CityLibrary.MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CityLibrary.MVC.RepositoryPattern
{
    public interface IBookRepository : IRepository<Book>
    {
        IList<Book> GetAllDetails();
        SelectList GetAuthorNameAndId();
        SelectList GetGenreIdAndType();
    }
}