using System.Collections.Generic;
using Softuni_RPG.GameObjects.Items;
using Softuni_RPG.GameObjects.Spells;

namespace Softuni_RPG.GameObjects.Entities
{
    public class Enemy : Entity
    {
        private const string imagePath = @"..\..\Resources\enemy.jpg";
        private List<Item> items;
        private List<Spell> spells;
        private EquipableItem itemEquiped;
        public Enemy(string name,double maxHealth):base(name,maxHealth,imagePath)
        {
            //TODO the same as players
            items = new List<Item>();
            this.spells = new List<Spell>();
            this.spells.Add(new DamageSpell("Basic Attack", @"..\..\Resources\basicDamageSpell.png", 20));
            this.spells.Add(new HealingSpell("Basic Heal", @"..\..\Resources\basicHealingSpell.jpg", 20));
        }

        public override string Collision()
        {
            return "battle";
        }

    }
}
