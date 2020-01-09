using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static void masss(string par)
        {
            if(par == null)
            {
                throw new Iskl2("ошибка при передаче в параметры null");
            }
            

        }
        public static void index()
        {
            int[] mass = new int [1] ;
            for(int i=0; i<2;i++)
            {
                if(i>=3)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    mass[i] = 1+i;
                }
            }


        }
        public static void delnull()
        {
            int x = 1;
            if (x == 0)
            {
                throw new Iskl3($"Деление на 0 невозможно");
            }
            else
            {
                int z = 5 / x;
            }
        }
        public static void METHOD()
        {
            int[] aa = null;
            Debug.Assert(aa != null, "Values array cannot be null");
        }
        
    }
}
