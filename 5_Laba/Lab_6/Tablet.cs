using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    sealed class Tablet: Tech
    {
        private float Price;
        private int Tax;
        private int Number;
        private float screenSize;
        public override float price { get { return this.Price; } set { this.Price = value + value * ((float)tax / 100.0f); } }
        public override int numberOfProducts { get { return this.Number; } set { this.Number = value; } }
        public override int tax { get { return this.Tax; } set { this.Tax = value; } }
        private int Year;
        public override int year { get => Year; set => this.Year = value; }
        public Tablet(float price, int tax, int number, float screen, int year)
        {
            this.tax = tax;
            this.price = price;
            this.numberOfProducts = number;
            this.screenSize = screen;
            this.year = year;
        }

        public override string sell()
        {
            return String.Format("There are {0} of tablets with {1} screen size each for {2}", numberOfProducts, screenSize, price);
        }
        public override string ToString()
        {
            return String.Format("{0}\nPrice is {1}\nTax is {2}\nNumber of products {3}\nScreen size is {4}", this.GetType(), this.price, this.tax, this.numberOfProducts, this.screenSize);
        }
        public override string SameName()
        {
            return "Inherited form abstract class";
        }
        public override int GetHashCode()
        {
            return Price.GetHashCode() + Tax.GetHashCode() + screenSize.GetHashCode() + 1;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            var temp = (Tablet)obj;
            if (temp.price == this.price && temp.tax == this.tax && temp.screenSize == this.screenSize)
                return true;
            else
                return false;
        }
    }
}
