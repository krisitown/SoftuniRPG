using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softuni_RPG.GameObjects.Interfaces;

namespace Softuni_RPG.GameObjects.Items
{
    public class AttackItem :EquipableItem,IAttackItem
    {
        private const double attackDefault = 10;
        private double attack;
        private const string itemDir = @"..\..\Resources\Iron_Axe.png";
        public AttackItem(string name, double attack) : base(name,Image.FromFile(itemDir))
        {
            this.Attack = attack;
        }

        public double Attack
        {
            get { return this.attack; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Defence should be non negative");
                }
                this.attack = value;
            }
        }

        public override void Use()
        {
            throw new NotImplementedException();
        }
    }
}
