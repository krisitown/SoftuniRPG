using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.Spells
{
    public class DamageSpell : Spell
    {
        public DamageSpell(string name, double power) 
            : base (name, power)
        {
        }

        public override void Use(Map_and_World.Entity target)
        {
            target.HP -= this.Power; //??think of a formula to include the target's defense too
        }
    }
}
