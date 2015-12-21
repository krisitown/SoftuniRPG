using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.GameObjects.Interfaces
{
    public interface IEntity:IGameObject,IPositionable,IAttackable,IDefencable
    {
        double MaxHealth { get; }
        double HP { get; set; }
        string Collision();
    }
}
