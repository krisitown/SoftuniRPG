using System;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Interfaces;

namespace Softuni_RPG.GameObjects.Items
{
    public abstract class UsableItem : Item,IUsableItem
    {
        protected UsableItem(string name, string imagePath)
            : base(name,imagePath)
        {
        }

        
        
    }
}
