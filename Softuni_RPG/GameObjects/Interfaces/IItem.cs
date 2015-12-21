using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.GameObjects.Interfaces
{
   public  interface IItem:IGameObject
    {
       decimal Price { get; }
    }
}
