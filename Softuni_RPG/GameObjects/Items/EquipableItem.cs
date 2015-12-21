using System;
using System.Drawing;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Interfaces;

namespace Softuni_RPG.GameObjects.Items
{
    public class EquipableItem : Item, IEquipable
    {
        private double attack;
        private double defence;
        public EquipableItem(string name, string imagePath, double attack, double defence)
            : base(name, imagePath)
        {
            this.Attack = attack;
            this.Defence = defence;
        }

        public double Attack
        {
            get { return this.attack; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("attack", "Attack can not be negative");
                }
                this.attack = value;
            }
        }

        public double Defence
        {
            get { return this.defence; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("defence", "Defence can not be negative");
                }
                this.defence = value;
            }
        }

        public override void Use()
        {
            
        }
    }
}
