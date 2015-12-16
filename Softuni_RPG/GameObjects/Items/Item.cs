using System;
using Softuni_RPG.GameObjects.Entities;
using System.Drawing;

namespace Softuni_RPG.GameObjects.Items
{
    public abstract class Item:GameObject
    {
      
       
        protected Item(string name,string imagePath) :base(name,imagePath)
        {
         
        }
   
        public abstract void Use();
    }
}
