using CityLibrary.MVC.Models;
using System.Data.Entity;

namespace CityLibrary.MVC.DbContext
{
    public class CityLibraryDbContext : System.Data.Entity.DbContext
    {
        public CityLibraryDbContext() : base("CityLibraryDb")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
    }
}