using Softuni_RPG.Map_and_World;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.Items
{
    public abstract class Item
    {
        private string name;

        protected Item(string name) 
        {
            this.Name = name;
        }

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

        

        public abstract void Use(Entity target);
    }
}
