using CityLibrary.MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CityLibrary.MVC.RepositoryPattern
{
    public interface IBookRepository : IRepository<Book>
    {
        IList<Book> GetAllDetails();
        //Dictionary<int,string> GetAuthorNameAndId();
        //Dictionary<int, string> GetGenreIdAndType();

        SelectList GetAuthorNameAndId();
        SelectList GetGenreIdAndType();

        SelectList GetAuthorNameAndId(int id);
        SelectList GetGenreIdAndType(int id);
    }
}