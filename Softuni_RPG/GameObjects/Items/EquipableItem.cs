using System.Drawing;
using System.Threading;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Items.Interfaces;

namespace Softuni_RPG.GameObjects.Items
{
    public abstract class EquipableItem : Item, IEquipableItem
    {
        private double attack;
        private double defence;
        protected EquipableItem(string name,double attack,double defence,Image image):base(name,image)
        {
            this.Attack = attack;
            this.Defence = defence;
        }

        

        public double Attack
        {
            get { return this.attack; }
            protected set
            {
                //check
                this.attack = value;
            }
        }
        public double Defence
       {
            get { return this.defence; }
            protected set
            {
                //check
                this.defence = value;
            }
        }

        public override void Use()
        {
          
        }
    }
}
