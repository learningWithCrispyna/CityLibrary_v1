namespace CityLibrary.MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CityLibrary.MVC.DbContext.CityLibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CityLibrary.MVC.DbContext.CityLibraryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Authors.AddOrUpdate(
                
                new Models.Author {
                    AuthorName = "Cris",
                    Id = 1
                },
                new Models.Author{
                    AuthorName = "Eusebiu",
                    Id = 2
                }

                );
            context.Books.AddOrUpdate(

                new Models.Book
                {
                    Id = 1,
                    Name = "Moby Dick",
                    AuthorId = 1,
                    GenreId = 1
                },
                new Models.Book
                {
                    Id = 2,
                    Name = "Unknown`s Story",
                    AuthorId = 1,
                    GenreId = 1
                },
                new Models.Book
                {
                    Id = 3,
                    Name = "Roses for Mom",
                    AuthorId = 1,
                    GenreId = 1
                }

                );

            context.Genres.AddOrUpdate(
                new Models.Genre
                {
                    Id = 1,
                    Type = "Drama"
                },
                new Models.Genre
                {
                    Id = 2,
                    Type = "Horror"
                }
                );

        }
    }
}
