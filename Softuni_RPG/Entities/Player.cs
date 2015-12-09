using Softuni_RPG.Items;
using Softuni_RPG.Map_and_World;
using Softuni_RPG.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.Entities
{
    public class Player : Entity
    {
        private List<Item> items;
        private List<Spell> spells;

        public Player()
        {
            items = new List<Item>();
            spells = new List<Spell>();
            spells.Add(new DamageSpell("Basic Attack", 20));
            spells.Add(new HealingSpell("Basic Heal", 20));
        }

        public void AddItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            this.items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            this.items.Remove(item);
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
            this.spells.Remove(spell);
        }
    }
}
