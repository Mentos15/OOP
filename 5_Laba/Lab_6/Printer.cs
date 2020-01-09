using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    partial class Printer : Tech, IInterfaceOne
    {
        private float Price;
        private int Tax;
        private int Number;
        public override float price { get { return this.Price; } set { this.Price = value + value * ((float)tax / 100.0f); } }
        public override int numberOfProducts { get { return this.Number; } set { this.Number = value; } }
        public override int tax { get { return this.Tax; } set { this.Tax = value; } }
        private int Year;
        public override int year { get => Year; set => this.Year = value; }

        public Printer(float price, int tax, int number, int year)
        {
            this.tax = tax;
            this.price = price;
            this.numberOfProducts = number;
            this.year = year;
        }

    }
}
