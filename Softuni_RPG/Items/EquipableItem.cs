using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softuni_RPG.Items.Interafces;
using Softuni_RPG.Map_and_World;

namespace Softuni_RPG.Items
{
    public abstract class EquipableItem : Item, IEquipableItem
    {
        private double power;
        private double defence;

        protected EquipableItem(string name,double power,double defence):base(name)
        {
            this.Power = power;
            this.Defence = defence;
        }
        public double Power
        {
            get { return this.power; }
            protected set
            {
                //check
                this.power = value;
            }
        }
        public double Defence
        {
            get { return this.defence; }
            protected set
            {
                //check
                this.defence = value;
            }
        }

        public override void Use(Entity target)
        {
            target.Defense += this.Defence;
            target.HP += this.Power;

        }
    }
}
