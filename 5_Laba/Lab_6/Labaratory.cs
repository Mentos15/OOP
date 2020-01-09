using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Labaratory
    {
        public List<Tech> _tech = new List<Tech>();
        public Tech get(int intdex)
        {
            return this._tech[intdex];
        }
        public void set(Tech tech)
        {
            this._tech.Add(tech);
        }
        public void Del(Tech tech)
        {
            if (this._tech.Contains(tech))
            {
                this._tech.Remove(tech);
            }
            else
                Console.WriteLine("This tech is not on the list");
        }
        public void Print()
        {
            foreach(Tech tech in this._tech)
            {
                Console.WriteLine(tech.ToString());
            }
        }
    }
}
