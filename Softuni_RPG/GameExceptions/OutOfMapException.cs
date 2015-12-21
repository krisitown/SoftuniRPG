using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni_RPG.GameExceptions
{
   public class OutOfMapException:System.Exception
    {
       public OutOfMapException(string message):base(message)
       {
           
       }
    }
}
