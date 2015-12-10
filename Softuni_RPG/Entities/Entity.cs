﻿using System;
using Softuni_RPG.Map_and_World;

namespace Softuni_RPG.Entities
{
    public abstract class Entity
    {
        private string name;
        private int x;
        private int y;
        private double hp;
        private double defense;
        private double maxHealth = Constants.maxPlayerHealth; 

        abstract public string Collision();

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name cannot be empty.");
                }
                this.name = value;
            }
        }

        public double MaxHealth {
            get { return this.maxHealth; }
            protected set { this.maxHealth = value; }
        }

        public double HP
        {
            get { return this.hp; }
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

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                //TODO: CHECK
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                //TODO: CHECK
                this.y = value;
            }
        }
    }
}
