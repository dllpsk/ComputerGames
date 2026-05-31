using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public class SingleGame : Game, IComputerable, IConsoleable
    {
        public override string GameMode => "Single";
        public string GetPlatformName() => "PC, Console";

        public SingleGame() { }
        public SingleGame(string title, string genre, int ageRating, DateTime releaseDate, double rating, string imageURL, string description = "")
            : base(title, genre, ageRating, releaseDate, rating, imageURL, description) { }
    }
}
