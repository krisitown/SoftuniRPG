using System.Drawing;
using System.Threading;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Interfaces;

namespace Softuni_RPG.GameObjects.Items
{
    public abstract class EquipableItem : Item, IEquipableItem
    {

        protected EquipableItem(string name, Image image) : base(name, image)
        {

        }
    }
}
