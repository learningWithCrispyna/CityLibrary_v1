﻿namespace CityLibrary.MVC.Models
{
    public class Book: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}