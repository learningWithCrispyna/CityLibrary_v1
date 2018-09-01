using CityLibrary.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityLibrary.MVC.RepositoryPattern
{
    public interface IUserRepository : IRepository<User>
    {
        IList<User> HamHam();
    }
}