using System;
using Softuni_RPG.Map_and_World;

namespace Softuni_RPG.Spells
{
    public class DamageSpell : Spell
    {
        public DamageSpell(string name, double power) 
            : base (name, power)
        {
        }

        public override void Use(Entity target)
        {

            double producedDamage = this.Power - target.Defense;

            if (producedDamage < 0)
            {
                producedDamage = 0;
            }

            target.HP -= producedDamage; 


        }
    }
}
