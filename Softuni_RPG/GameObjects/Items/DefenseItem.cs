using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Interfaces;

namespace Softuni_RPG.GameObjects.Items
{
    class DefenseItem : EquipableItem, IDefenceItem
    {
        private const string itemDir = @"..\..\Resources\armor.png";

        private double defence;
        public DefenseItem(string name, string imagePath,double defence)
            : base(name,imagePath)
        {
            this.Defence = defence;
        }

        public double Defence
        {
            get { return this.defence; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Defence should be non negative");
                }
                this.defence = value;
            }
        }


        public override void Use()
        {
            throw new NotImplementedException();
        }
    }
}
