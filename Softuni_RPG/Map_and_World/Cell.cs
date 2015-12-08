﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Softuni_RPG.Map_and_World
{
    public class Cell
    {
        private bool isOccupied = false;
        private Entity occupator;
        private bool isPassable;
        private Image image;

        public Cell(bool isPassable, Image image, Entity occupator = null)
        {
            this.Image = image;
            this.IsPassable = isPassable;
            if (occupator != null)
            {
                this.Occupator = occupator;
                this.isOccupied = true;
            }
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
            private set { this.image = value; }
        }

        public Entity Occupator
        {
            get { return this.occupator; }
            set { this.occupator = value; }
        }
    }
}