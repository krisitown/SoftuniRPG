using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softuni_RPG.Entities;
using Softuni_RPG.Items.Interfaces;
using Softuni_RPG.Items.Interfaces;
using Softuni_RPG.Map_and_World;

namespace Softuni_RPG.Items
{
    public abstract class EquipableItem : Item, IEquipableItem
    {
        private double powerFactor;
        private double defenceFactor;

        protected EquipableItem(string name,double powerFactor,double defenceFacotr):base(name)
        {
            this.PowerFactor = powerFactor;
            this.DefenceFactor = defenceFactor;
        }
        public double PowerFactor
        {
            get { return this.powerFactor; }
            protected set
            {
                //check
                this.powerFactor = value;
            }
        }
        public double DefenceFactor
       {
            get { return this.defenceFactor; }
            protected set
            {
                //check
                this.defenceFactor = value;
            }
        }

        public override void Use(Entity target)
        {
          
        }
    }
}
