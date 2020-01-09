using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    partial class Printer
    {
        public virtual void Print(string textToPrint)
        {
            Console.WriteLine("Printing:\n\t" + textToPrint + "\nPrinted.");
        }

        public override string sell()
        {
            return String.Format("This printer is sold for {0}", price);
        }
        public override string ToString()
        {
            return String.Format("{0}\nPrice is {1}\nTax is {2}\nNumber of products {3}", this.GetType(), this.price, this.tax, this.numberOfProducts);
        }

        string IInterfaceOne.SameName()
        {
            return "Inherited from Interface";
        }

        public override string SameName()
        {
            return "Inherited from abstract class";
        }
    }



    sealed class Scaner : Printer
    {

        PaperType paper = new PaperType();
        public Scaner(float price, int tax, int number, int year, int paperType) : base(price, tax, number, year)
        {
            if (paperType -1 == 0)
                this.paper = PaperType.A1;
            else if (paperType -1 == 1)
                this.paper = PaperType.A2;
            else if (paperType -1 == 2)
                this.paper = PaperType.A3;
            else if (paperType -1 == 3)
                this.paper = PaperType.A4;
            else
            {
                Console.WriteLine("Wrong paper type default is A4");
                this.paper = PaperType.A4;
            }
        }

        enum PaperType
        {
            A1,
            A2,
            A3,
            A4
        }
        private string scanned;
        public void Scan(string s)
        {
            Console.WriteLine("Scanning...");
            this.scanned = s;
            Console.WriteLine("Scanned successfully");
        }
        public void PrintScannedPage()
        {
            if (!String.IsNullOrEmpty(scanned))
                base.Print(scanned);
            else Console.WriteLine("Nothing was scanned to print");
        }
        public override void Print(string textToPrint)
        {
            Console.WriteLine("Scanning and printing:\n\t" + textToPrint + "\nPrinted.");
            this.scanned = textToPrint;
        }
        public override string ToString()
        {
            return String.Format("{0}\nPrice is {1}\nTax is {2}\nNumber of products {3}", this.GetType(), this.price, this.tax, this.numberOfProducts);
        }
        
    }
}
