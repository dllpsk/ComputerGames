using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public abstract class Game
    {   
        public string Title { get; set; }
        public string Genre { get; set; }
        public int AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public string ImageURL { get; set; }
        public abstract string GameMode { get; }

        protected Game() { }
        protected Game(string title, string genre, int ageRating, DateTime releaseDate, double rating, string imageURL)
        {
            Title = title;
            Genre = genre;
            AgeRating = ageRating;
            ReleaseDate = releaseDate;
            Rating = rating;
            ImageURL = imageURL;
        }
    }
}
