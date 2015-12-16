using System;
using Softuni_RPG.GameObjects.Entities;

namespace Softuni_RPG.GameObjects.Spells
{
    public abstract class Spell
    {
        private double power; //defines how much the spell will damage/heal

        protected Spell(string name, double power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of a spell cannot be empty.");
                }
                this.name = value;
            }
        }

        public double Power
        {
            get { return this.power; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The power of the spell cannot be negative");
                }
                this.power = value;
            }
        }

        public abstract void Use(Entity target); //the target could be the player or the enemy depending on the type of spell
    }
}
