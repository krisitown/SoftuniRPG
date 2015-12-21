using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Interfaces;
using Softuni_RPG.GameObjects.Items;
using Softuni_RPG.Resources;

namespace Softuni_RPG.Factories
{
    public static class RandomFactory
    {
        private static Random rnd = new Random();

        public static IItem CreateItem()
        {
            return new EquipableItem("Item_Name", Constants.itemImage, rnd.NextDouble()* 20, rnd.NextDouble()*12);
        }

        public static Enemy CreatEnemy()
        {
            return new Enemy("Enemy_Name", rnd.NextDouble()*100);
        }

        //FIND A WAY TO CREATE RANDOM NAMES, MAYBE GETTING A RANDOM LINE FROM A TXT FILE
    }
}
