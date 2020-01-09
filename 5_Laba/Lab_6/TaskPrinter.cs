using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class TaskPrinter
    {
        public virtual void IAmPrinting(IProduct prod)
        {
            Console.WriteLine(prod.GetType()+ "\n" + prod.ToString());
        }
    }
}
