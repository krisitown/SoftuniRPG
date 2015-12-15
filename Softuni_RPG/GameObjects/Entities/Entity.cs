using System;
using Softuni_RPG.Map_and_World;

namespace Softuni_RPG.GameObjects.Entities
{
    public abstract class Entity
    {
        private string name;
        private int x;
        private int y;
        private double hp;
        private double defense;
        private double attack;
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

        public double Attack { get { return this.attack; } set { this.attack = value; } }

        public double HP
        {
            get { return this.hp; }
            set
            {
                //TODO: CHECK
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("HP", "Can't be less than zero!");
                }
                this.hp = value;
            }
        }

        public double Defense
        {
            get { return this.defense; }
            set
            {
                //TODO: CHECK
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Defense", "Can't be negative!");
                }
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
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException("Coordinate X", "Can't be negative or greater than 9!");
                }
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
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException("Coordinate Y", "Can't be negative or greater than 9!");
                }
                this.y = value;
            }
        }
    }
}
