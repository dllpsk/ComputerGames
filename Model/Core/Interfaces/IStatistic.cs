using Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public interface IStatistic
    {
        double MaxRating(List<Game> games);
        double MinRating(List<Game> games);
        double AverageRating(List<Game> games);
        double MedianRating(List<Game> games);
    }
}
