using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softuni_RPG.GameObjects.Items;

namespace Softuni_RPG
{
    public class ItemUI
    {
        
        public ItemUI(Item item)
        {
            Item = item;
        }

        public Item Item { get; set; }
    }
}
