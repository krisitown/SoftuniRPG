using System;
using Softuni_RPG.GameObjects.Entities;
using System.Drawing;
using Softuni_RPG.GameObjects.Interfaces;

namespace Softuni_RPG.GameObjects.Items
{
    public abstract class Item:GameObject,IItem
    {
        private decimal price;
       
        protected Item(string name,string imagePath,decimal Price) :base(name,imagePath)
        {
         
        }
   
        public abstract void Use();

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("price", "Price should be positive");

                }
                this.price = value;
            }
        }
    }
}
