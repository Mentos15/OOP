using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    class Iskl1: OverflowException
    {
        public Iskl1(string diap):base(diap)
        {
            
        }
    }
    class Iskl2:Exception
    {
        
        public Iskl2(string par) : base(par)
        {
            
        }
    }

    class Iskl3: DivideByZeroException
    {
        public Iskl3(string par) : base(par)
        {

        }
    }
}
