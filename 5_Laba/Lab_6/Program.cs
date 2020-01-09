using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Labaratory lab = new Labaratory();
            Printer pr1 = new Printer(1000000f, 23, 100, 1991);
            Printer pr2 = new Printer(10f, 23, 100, 2005);
            Computer pr3 = new Computer(1000f, 16, 45, "intel", "nvidia", 2018);

            lab.set(pr1); lab.set(pr2); lab.set(pr3);
            lab.Print();
            Console.WriteLine("\n\n\n");
            LabController.PriceL(lab).Print();

            Console.WriteLine("\n\n\n");
            LabController.YearsOfService(lab,2000).Print();
        }
    }
}
