using CityLibrary.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityLibrary.MVC.RepositoryPattern
{
    public interface IGenreRepository : IRepository<Genre>
    {
        IList<Genre> GetFullNameForGen();
    }
}