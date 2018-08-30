using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityLibrary.MVC.RepositoryPattern
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(CityLibraryDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Author> GetWhereNamesAreFull()
        {
            return _dbSet.Where(x => !string.IsNullOrEmpty(x.AuthorName)).ToList();
        }
    }
}