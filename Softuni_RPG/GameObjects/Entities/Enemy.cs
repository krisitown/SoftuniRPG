using System.Collections.Generic;
using Softuni_RPG.GameObjects.Items;
using Softuni_RPG.GameObjects.Spells;

namespace Softuni_RPG.GameObjects.Entities
{
    public class Enemy : Entity
    {
        private List<Item> items;
        private List<Spell> spells;
        private EquipableItem itemEquiped;
        public Enemy()
        {
            //TODO the same as players
            items = new List<Item>();
            spells = new List<Spell>();
            spells.Add(new DamageSpell("Basic Attack", 20));
            spells.Add(new HealingSpell("Basic Heal", 20));
        }

        public override string Collision()
        {
            return "battle";
        }

    }
}
