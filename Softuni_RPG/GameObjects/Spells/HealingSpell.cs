using Softuni_RPG.GameObjects.Entities;

namespace Softuni_RPG.GameObjects.Spells
{
    public class HealingSpell : Spell
    {
        public HealingSpell(string name, double power) 
            : base (name, power)
        {
        }

        public override void Use(Entity target)
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
