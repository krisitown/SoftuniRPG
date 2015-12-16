using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.GameObjects.Interfaces
{
    public interface IGameObject
    {
        string Name { get; }
        Image Image { get; }
    }
}
