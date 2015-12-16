using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.GameObjects.Interfaces
{
    public interface IEntity
    {
        string Name { get; }
        int X { get; }
        int Y { get; }
    }
}
