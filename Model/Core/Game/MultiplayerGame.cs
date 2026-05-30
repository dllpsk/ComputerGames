using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public class MultiplayerGame : Game, IConsoleable, IComputerable, IMobile
    {
        public override string GameMode => "Multiplayer";
        public string GetPlatformName() => "PC, Console, Mobile";

        public MultiplayerGame() { }
        public MultiplayerGame(string title, string genre, int ageRating, DateTime releaseDate, double rating, string imageURL)
            : base(title, genre, ageRating, releaseDate, rating, imageURL) { }
    }
}
