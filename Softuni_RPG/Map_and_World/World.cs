using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.Map_and_World
{
    public class World
    {
        private const int numberOfMaps = 5; //could be changed whenver we decide
        private Map[] maps;
        private static int currentMap = 0;

        public World(string mapPath, double mapQuantity = numberOfMaps)
        {
            maps = new Map[numberOfMaps];
            for (int i = 0; i < numberOfMaps; i++)
            {
                maps[i] = new Map(mapPath + "map" + i + ".txt");
            }
        }

        public static int CurrentMapIndex
        {
            get { return currentMap; }
            set
            {
                if (value > numberOfMaps || value < 0)
                {
                    throw new ArgumentOutOfRangeException("The current map cannot be negative or more than the total number of maps");
                }
            }
        }

        public Map CurrentMap()
        {
            return this.maps[currentMap];
        }

        public Map NextMap()
        {
            if (currentMap == numberOfMaps - 1)
            {
                throw new ArgumentOutOfRangeException("There is no next map!");
            }
            currentMap++;
            return this.maps[currentMap];
        }

        public Map PreviousMap()
        {
            if (currentMap == 0)
            {
                throw new ArgumentOutOfRangeException("This is the first map!");
            }
            currentMap--;
            return this.maps[currentMap];
        }
    }
}
