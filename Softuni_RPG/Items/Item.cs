using Softuni_RPG.Map_and_World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.Items
{
    public abstract class Item
    {
        private string name;
        private double power;
        private double defense;

        public Item(string name, double power, double defense) 
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of an item cannot be empty.");
                }
                this.name = value;
            }
        }

        public double Power
        {
            get { return this.power; }
            set
            {
                //check
                this.power = value;
            }
        }

        public double Defense
        {
            get { return this.defense; }
            set
            {
                //check
                this.defense = value;
            }
        }

        public abstract void Use(Entity target);
    }
}
