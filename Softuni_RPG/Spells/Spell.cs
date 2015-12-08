﻿using Softuni_RPG.Map_and_World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.Spells
{
    public abstract class Spell
    {
        private string name;
        private double power; //defines how much the spell will damage/heal

        public Spell(string name, double power)
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
