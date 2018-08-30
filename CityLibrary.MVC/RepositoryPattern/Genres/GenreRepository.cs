using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityLibrary.MVC.RepositoryPattern
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(CityLibraryDbContext dbContext) : base(dbContext)
        {

        }

        public IList<Genre> GetFullNameForGen()
        {
            return _dbContext.Genres.Where(x => !string.IsNullOrEmpty(x.Type)).ToList();
        }
    }
}