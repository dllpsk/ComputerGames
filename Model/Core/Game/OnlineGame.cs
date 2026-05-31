using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public class OnlineGame : Game, IComputerable, IMobile
    {
        public override string GameMode => "Online";
        public string GetPlatformName() => "PC, Mobile";

        public OnlineGame() { }
        public OnlineGame(string title, string genre, int ageRating, DateTime releaseDate, double rating, string imageURL, string description = "")
            : base(title, genre, ageRating, releaseDate, rating, imageURL, description) { }

    }
}
