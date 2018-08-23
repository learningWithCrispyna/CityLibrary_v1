using CityLibrary.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrary.MVC.RepositoryPattern
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IList<Author> GetWhereNamesAreFull();
    }
}
