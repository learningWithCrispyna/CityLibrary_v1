using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using System;

namespace CityLibrary.MVC.RepositoryPattern
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(CityLibraryDbContext dbContext) : base(dbContext)
        {

        }

        public IList<Book> GetAllDetails()
        {
            var result = _dbContext.Books.Include(a => a.Author).Include(b => b.Genre).ToList();
            return result;
        }

        public Dictionary<int, string> GetBookAuthors()
        {
            return _dbContext.Authors.ToDictionary(x => x.Id, x => x.AuthorName);
        }

        public Dictionary<int, string> GetBookGenres()
        {
            return _dbContext.Genres.ToDictionary(x => x.Id, x => x.Type);
        }
    }
}