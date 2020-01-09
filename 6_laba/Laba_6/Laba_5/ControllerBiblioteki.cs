using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    class ControllerBiblioteki
    {
        
        public static Biblioteka BigYear(Book[] array, int year)
        {
            int i = 0;
            Biblioteka listAge = new Biblioteka();
            foreach (Book b in array)
            {
                if (year < b.Year)
                {
                    listAge.set(b);
                    Console.WriteLine(listAge.uch[i]);
                    i++;
                    Console.Write("--------------------\n");
                }
            }
            
            return listAge;

        }
        public static int SummUch()
        {

            return Uchebnik.count;
        }
       
        
    }
}
