using System.Collections.Generic;
using Softuni_RPG.GameObjects.Items;
using Softuni_RPG.GameObjects.Spells;
using Softuni_RPG.Resources;

namespace Softuni_RPG.GameObjects.Entities
{
    public class Enemy : Entity
    {
        
        private List<Item> items;
        private List<Spell> spells;
        private EquipableItem itemEquiped;
        public Enemy(string name,double maxHealth):base(name,Constants.maxEnemyHealth,Constants.enemyImagePath)
        {
            //TODO the same as players
            items = new List<Item>();
            this.spells = new List<Spell>();
            this.spells.Add(new DamageSpell(Constants.basicDamageSpellName, Constants.basicDamageSpellPath, 20));
            this.spells.Add(new HealingSpell(Constants.basicHealSpellName, Constants.basicHealingSpellPath, 20));
        }

        public override string Collision()
        {
            return "battle";
        }

    }
}
