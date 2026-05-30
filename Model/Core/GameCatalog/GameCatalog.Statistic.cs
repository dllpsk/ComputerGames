using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public partial class GameCatalog : IStatistic
    {
        public double MaxRating(List<Game> games)
        {
            if (games == null || games.Count == 0) return 0;
            double mx = games.Max(g => g.Rating);
            return mx;

        }
        public double MinRating(List<Game> games)
        {
            if (games == null || games.Count == 0) return 0;
            double mn = games.Min(g => g.Rating);
            return mn;
        }
        public double AverageRating(List<Game> games)
        {
            if (games == null || games.Count == 0) return 0;
            double c = 0;
            double sum = 0;
            for (int i = 0; i < games.Count; i++)
            {
                sum += games[i].Rating;
                c++;
            }
            double sr = sum / c;
            return sr;
        }
        public double MedianRating(List<Game> games)
        {
            if (games == null || games.Count == 0) return 0;
            var sort = games.Select(g => g.Rating).OrderBy(g => g).ToList();
            int count = sort.Count;
            int mid = count / 2;
            double itog = 0;
            if (count % 2 == 0)
            {
                return (sort[mid - 1] + sort[mid]) / 2.0;
            }
            else
            {
                return sort[mid];
            }
        }
    }
}
