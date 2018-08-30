using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace CityLibrary.MVC.RepositoryPattern
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(CityLibraryDbContext dbContext) : base(dbContext)
        {

        }

        public IList<Book> GetFullNamesOfBooks()
        {
            return _dbSet.Where(x => !string.IsNullOrEmpty(x.Name)).ToList();
        }
    }
}