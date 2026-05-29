using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core.Interfaces
{
    public interface IGameCatalog
    {
        void Add(Game game);
        void Remove(Game game);
    }
}
