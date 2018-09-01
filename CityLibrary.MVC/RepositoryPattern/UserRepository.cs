using CityLibrary.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityLibrary.MVC.DbContext;

namespace CityLibrary.MVC.RepositoryPattern
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CityLibraryDbContext dbContext) : base(dbContext)
        {
        }

        public IList<User> HamHam()
        {
            throw new NotImplementedException();
        }
    }
}