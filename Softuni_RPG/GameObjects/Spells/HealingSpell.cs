using System.Linq.Expressions;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Interfaces;

namespace Softuni_RPG.GameObjects.Spells
{
    public class HealingSpell : Spell
    {
        public HealingSpell(string name,string imagePath, double power) 
            : base (name,imagePath,power)
        {
        }

        public override void Use(IEntity target)
        {

            double healedHealth = target.HP + this.Power;

            if (healedHealth > target.MaxHealth)
            {
                healedHealth = target.MaxHealth;
            }

            target.HP = healedHealth;
        }
    }
}
