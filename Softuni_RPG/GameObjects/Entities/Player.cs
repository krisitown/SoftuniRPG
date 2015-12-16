using System;
using System.Collections.Generic;
using System.Drawing;
using Softuni_RPG.GameObjects.Items;
using Softuni_RPG.GameObjects.Spells;

namespace Softuni_RPG.GameObjects.Entities
{
    public class Player : Entity
    {

        private  const string playerImagePath=@"..\..\Resources\code_wizard.png";
        private const double maxHealth = 50;

        private List<Item> items;
        private List<Spell> spells;
        private EquipableItem itemEquiped;
        public Player(string name):base(name,maxHealth,playerImagePath)
        {
            items = new List<Item>();
            spells = new List<Spell>();
            spells.Add(new DamageSpell("Basic Attack", 20));
            spells.Add(new HealingSpell("Basic Heal", 20));
        }

        public IList<Item> Items { get { return this.items; } }
        public EquipableItem ItemEquiped { get { return this.itemEquiped; } set { this.itemEquiped = value; } }
        public List<Spell> Spells { get { return this.spells; } }
    
        public void AddItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            this.items.Add(item);
        }

        public void EquipItem(EquipableItem item)
        {
            if (ItemEquiped != null)
            {
                this.Attack -= ItemEquiped.Attack;
                this.Defense -= ItemEquiped.Defence;
            }
            this.Attack += item.Attack;
            this.Defense += item.Defence;
            ItemEquiped = item;
        }
        public void RemoveItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            if (this.items.Contains(item))
            {
                this.items.Remove(item);
            }
            
        }
        
        public void AddSpell(Spell spell)
        {
            if (spell == null)
            {
                throw new ArgumentNullException();
            }
            this.spells.Add(spell);
        }

        public void RemoveSpell(Spell spell)
        {
            if (spell == null)
            {
                throw new ArgumentNullException();
            }

            if (this.spells.Contains(spell))
            {
                this.spells.Remove(spell);
            }
            
        }

        public void UseSpell(Spell spell,Enemy enemy)
        {
            //TODO apply spells effect on enemies;
            throw new NotImplementedException();
        }
        public override string Collision()
        {
            throw new NotImplementedException();
        }
    }
}
