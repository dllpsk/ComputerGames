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
        public string Description { get; set; }
        public abstract string GameMode { get; }

        protected Game() { }
        protected Game(string title, string genre, int ageRating, DateTime releaseDate, double rating, string imageURL, string description)
        {
            Title = title;
            Genre = genre;
            AgeRating = ageRating;
            ReleaseDate = releaseDate;
            Rating = rating;
            ImageURL = imageURL;
            Description = description;
        }
        // Перегрузка операторов > и < для сравнения названий игр по алфавиту
        public static bool operator >(Game g1, Game g2)
        {
            if (g1 is null || g2 is null) return false;
            return string.Compare(g1.Title, g2.Title, StringComparison.OrdinalIgnoreCase) > 0;
        }
        public static bool operator <(Game g1, Game g2)
        {
            if (g1 is null || g2 is null) return false;
            return string.Compare(g1.Title, g2.Title, StringComparison.OrdinalIgnoreCase) < 0;
        }
    }
}