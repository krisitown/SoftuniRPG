using System;
using Softuni_RPG.GameObjects.Entities;
using System.Drawing;

namespace Softuni_RPG.GameObjects.Items
{
    public abstract class Item
    {
        private string name;
        private Image img;
        protected Item(string name,Image image) 
        {
            this.img = image;
            this.Name = name;
        }
        public Image ItemImage { get { return this.img; } }
        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of an item cannot be empty.");
                }
                this.name = value;
            }
        }

        

        public abstract void Use();
    }
}
