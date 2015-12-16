using System;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Interfaces;

namespace Softuni_RPG.GameObjects.Spells
{
    public abstract class Spell:GameObject
    {
        private double power; //defines how much the spell will damage/heal

        protected Spell(string name, string imagePath,double power):base(name,imagePath)
        {  
            this.Power = power;
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

        public abstract void Use(IEntity target); //the target could be the player or the enemy depending on the type of spell
    }
}
