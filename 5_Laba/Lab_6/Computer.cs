using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Computer : Tech
    {
        private float Price;
        private int Tax;
        private int Number;
        private string processor;
        private string videocard;
        private Periferals perf = new Periferals();
        public override float price { get { return this.Price; } set { this.Price = value + value * ((float)tax / 100.0f); } }
        public override int numberOfProducts { get { return this.Number; } set { this.Number = value; } }
        public override int tax { get { return this.Tax; } set { this.Tax = value; } }
        private int Year;
        public override int year { get => Year; set => this.Year = value; }
        public Computer(float price, int tax, int number, string processor, string videocard, int year){
            this.tax = tax;
            this.price = price;
            this.numberOfProducts = number;
            this.processor = processor;
            this.videocard = videocard;
            this.year = year;
        }

        public override string sell()
        {
            return String.Format("There are {0} computers with {1} processor and {2} videocard each for {3}", numberOfProducts, processor, videocard, price);
        }
        public override string ToString()
        {
            return String.Format("{0}\nPrice is {1}\nTax is {2}\nNumber of products {3}\nProcessor is {4}\nVideocard is {5}", this.GetType(), this.price, this.tax, this.numberOfProducts, this.processor, this.videocard);
        }
        public override string SameName()
        {
            return "Inherited form abstract class";
        }
        public struct Periferals
        {
            public string mouse;
            public string keyboard;
            public string headphones;
            public string display;
        }

        public void RegisterPEriferals(string mouse, string keyboard, string headphones, string display)
        {
            this.perf.mouse = mouse;
            this.perf.keyboard = keyboard;
            this.perf.headphones = headphones;
            this.perf.display = display;
        }
    }
}
