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

        public override void Create(User user)
        {
            var result = _dbContext.Users.Where(x => x.Name == user.Name).FirstOrDefault();
            if (result == null)
            {
                base.Create(user);
            }
        }
    }
}