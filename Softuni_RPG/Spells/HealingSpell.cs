using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softuni_RPG.Entities;

namespace Softuni_RPG.Spells
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
