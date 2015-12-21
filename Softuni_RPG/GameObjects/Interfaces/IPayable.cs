using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Softuni_RPG.GameObjects.Interfaces
{
    public interface IPayable
    {
        decimal Money { get; set; }
        void BuyItem(IItem item);
    }
}
