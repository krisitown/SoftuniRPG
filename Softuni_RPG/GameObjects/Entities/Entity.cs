using System;
using Softuni_RPG.GameObjects.Interfaces;
using Softuni_RPG.Map_and_World;

namespace Softuni_RPG.GameObjects.Entities
{
    public abstract class Entity : GameObject, IEntity
    {

        private int x;
        private int y;
        private double hp;
        private double defence;
        private double attack;
        private double maxHealth;


        protected Entity(string name, double maxHealth, string imagePath)
            : base(name, imagePath)
        {
            this.MaxHealth = maxHealth;
        }

        abstract public string Collision();


        public double MaxHealth
        {
            get
            {
               
                return this.maxHealth;
            }
            protected set { this.maxHealth = value; }
        }

        public double Attack { get { return this.attack; } set { this.attack = value; } }

        public double HP
        {
            get { return this.hp; }
            set
            {

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("HP", "Can't be less than zero!");
                }
                this.hp = value;
            }
        }

        public double Defence
        {
            get { return this.defence; }
            set
            {

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Defense", "Can't be negative!");
                }
                this.defence = value;
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
