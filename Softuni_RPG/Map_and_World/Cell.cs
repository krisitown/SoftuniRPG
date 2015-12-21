using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Interfaces;

namespace Softuni_RPG.Map_and_World
{
    public class Cell
    {
        private bool isOccupied = false;
        private Enemy occupator;
        private IItem item;
        private bool hasItem;

        private bool isPassable;
        private Image image;
       
        public Cell(bool isPassable, Image image, IItem item = null, Enemy occupator = null)
        {
            this.Image = image;
            this.IsPassable = isPassable;
            if (occupator != null)
            {
                this.Occupator = occupator;
                this.isOccupied = true;
            }
            if (item != null)
            {
                this.Item = item;
                this.HasItem = true;
            }
        }

        public IItem Item
        {
            get { return item; }
            set { item = value; }
        }

        public bool HasItem
        {
            get { return hasItem; }
            set { hasItem = value; }
        }

        public bool IsOccupied
        {
            get { return this.isOccupied; }
            set { this.isOccupied = value; }
        }

        public bool IsPassable
        {
            get { return this.isPassable; }
            private set { this.isPassable = value; }
        }

        public Image Image
        {
            get { return this.image; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The image of a cell cannot be with the value of null");
                }
                this.image = value;
            }
        }

        public Enemy Occupator
        {
            get { return this.occupator; }
            set { this.occupator = value; }
        }
    }
}
