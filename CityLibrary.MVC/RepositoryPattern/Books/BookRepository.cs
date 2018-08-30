using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

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

        public SelectList GetAuthorNameAndId()
        {
            return new SelectList(_dbContext.Authors, "Id", "AuthorName"); ;
        }

        public SelectList GetGenreIdAndType()
        {
            return new SelectList(_dbContext.Genres, "Id", "Type");
        }
    }
}