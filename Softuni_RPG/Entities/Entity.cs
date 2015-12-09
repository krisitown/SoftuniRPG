using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Softuni_RPG.Map_and_World
{
    public abstract class Entity
    {
        private string name;
        private double hp;
        private double defense;
        private readonly double maxHealth; 

        abstract public string Collision();

        public string Name
        {
            get { return this.Name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name cannot be empty.");
                }
                this.name = value;
            }
        }

        public double MaxHealth { get; protected set; }

        public double HP
        {
            get { return this.HP; }
            set
            {
                //TODO: CHECK
                this.hp = value;
            }
        }

        public double Defense
        {
            get { return this.defense; }
            set
            {
                //TODO: CHECK
                this.defense = value;
            }
        }
    }
}
