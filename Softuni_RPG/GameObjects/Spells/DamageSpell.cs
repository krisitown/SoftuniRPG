using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Interfaces;

namespace Softuni_RPG.GameObjects.Spells
{
    public class DamageSpell : Spell
    {
        public DamageSpell(string name, string imagePath,double power) :base(name,imagePath,power)      
        {
        }

        public override void Use(IEntity target)
        {

                double producedDamage = this.Power - target.Defence;

                if (producedDamage < 0)
                {
                    producedDamage = 0;
                }

                target.HP -= producedDamage; 


        }
    }
}
