using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public partial class GameCatalog
    {
        public delegate bool GameFilter(Game game);

        // сортировка по алфавиту для всего каталога
        public List<Game> SortGames()
        {
            if (_games == null || _games.Count == 0) return null;
            List<Game> itog = new List<Game>(_games);
            for (int i = 0; i < itog.Count; i++)
            {
                for (int j = 1; j < itog.Count; j++)
                {
                    if (String.Compare(itog[j - 1].Title, itog[j].Title) > 0)
                    {
                        (itog[j - 1], itog[j]) = (itog[j], itog[j - 1]);
                    }
                }
            }
            return itog;
        }
        // сортировка по алфавиту 
        public List<Game> SortGames(List<Game> games)
        {
            if (games == null || games.Count == 0) return new List<Game>();

            List<Game> itog = new List<Game>(games);
            for (int i = 0; i < itog.Count; i++)
            {
                for (int j = 1; j < itog.Count; j++)
                {
                    if (itog[j - 1] > itog[j])
                    {
                        (itog[j - 1], itog[j]) = (itog[j], itog[j - 1]);
                    }

                }
            }
            return itog;
        }
        // сортировка по игровому режиму
        public List<Game> SortMode(List<Game> games1, string mode)
        {
            if (games1 == null || games1.Count == 0) return new List<Game>();
            if (mode != "Multiplayer" && mode != "Single" && mode != "Online") return SortGames(games1);

            GameFilter filter = g => g.GameMode.Equals(mode, StringComparison.OrdinalIgnoreCase);

            List<Game> itog = new List<Game>();
            foreach (var game in games1)
            { 
                if (filter(game))
                {
                    itog.Add(game);
                }
            }
            return itog;
        }
        // сортировка по платформе 
        public List<Game> SortPlatform(List<Game> games1, string platform)
        {
            if (games1 == null || games1.Count == 0) return new List<Game>();
            if (platform != "PC" && platform != "Console" && platform != "Mobile") return SortGames(games1);

            GameFilter filter = platform switch
            {
                "PC" => g => g is IComputerable,
                "Console" => g => g is IConsoleable,
                "Mobile" => g => g is IMobile,
                _ => g => false
            };

            List<Game> itog = new List<Game>();
            foreach (var game in games1)
            {
                if (filter(game))
                {
                    itog.Add(game);
                }
            }
            return itog;
        }

    }
}
