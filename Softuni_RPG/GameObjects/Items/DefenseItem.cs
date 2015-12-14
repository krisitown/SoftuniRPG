using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softuni_RPG.GameObjects.Entities;

namespace Softuni_RPG.GameObjects.Items
{
    class DefenseItem : EquipableItem
    {
        private const int attackDefault = 0;
        private const string itemDir = @"..\..\Resources\armor.png";
        public DefenseItem(string name, double defence) : base(name, attackDefault, defence, Image.FromFile(itemDir))
        {

        }

    }
}
