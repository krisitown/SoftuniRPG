using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Softuni_RPG.GameObjects.Items
{
    public class NoMoneyException:System.Exception
    {
        public NoMoneyException(string msg):base(msg)
        {
                
        }
    }
}
