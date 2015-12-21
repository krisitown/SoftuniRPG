using System;
using Softuni_RPG.GameExceptions;
using Softuni_RPG.GameObjects.Interfaces;
using Softuni_RPG.Map_and_World;
using Softuni_RPG.Resources;

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
                //to do
                if (value < Constants.minX || value > Constants.maxX)
                {
                    throw new OutOfMapException(string.Format("Can't be less than {0} or greater than {1}!",Constants.minX,Constants.maxX));
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
                if (value < Constants.minY || value > Constants.maxY)
                {
                     throw new OutOfMapException(string.Format("Can't be less than {0} or greater than {1}!",Constants.minY,Constants.maxY));
                }
                this.y = value;
            }
        }
    }
}
