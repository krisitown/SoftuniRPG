using Softuni_RPG.Map_and_World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.Entities
{
    class Enemy : Entity
    {
        private readonly double maxHealth = 100;

        public override string Collision()
        {
            return "battle";
        }

    }
}
