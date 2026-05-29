using Model.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Model.Core
{
    public partial class GameCatalog : IGameCatalog
    {
        public void Add(Game game)
        {
            if (game != null && !_games.Exists(g => g.Title == game.Title))
            {
                _games.Add(game);
            }
        }
        public void Remove(Game game)
        {
            if (game != null && _games.Exists(g => g.Title == game.Title))
            {
                _games.Remove(game);
            }
        }
    }
}
