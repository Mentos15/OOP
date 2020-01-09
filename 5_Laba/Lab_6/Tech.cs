using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    abstract class Tech: IProduct, IComparable
    {
        abstract public int year { get; set; }

        abstract public int tax { get; set; }

        abstract public float price { get; set; }
        abstract public int numberOfProducts { get; set; }

        public abstract string sell();

        public abstract string SameName();


        public int CompareTo(object o)
        {
            Tech p = o as Tech;
            if (p != null)
                return this.price.CompareTo(p.price);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
