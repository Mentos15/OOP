using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        class Card:IComparable
        {
            public int ExpData { get; set; }
            public int Number { get; set; }
            public int Sum { get; set; }
            public static int Bank { get; set; }


            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }
            public void Sort(Card[] arg)
            {
               Card sohr;
               
               for(int i=0;i<arg.Length -1;i++)
                {
                    if(arg[i].Sum >= arg[i+1].Sum)
                    {
                       sohr= arg[i];
                       arg[i] = arg[i + 1];
                       arg[i + 1] = sohr;


                    }
                }
                for (int i = 0; i <=arg.Length-1; i++)
                {
                    
                    Console.WriteLine($"{arg[i].ExpData} ,{arg[i].Number}, {arg[i].Sum}");
                }
                
                
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1 задание");
            Console.WriteLine(ulong.MaxValue);
            string stroka = Console.ReadLine();
            
            for(int i =0;i<stroka.Length-1;i++)
            {
                if(stroka[i+1]==' ')
                {
                    stroka = stroka.Remove(i,1);
                }
            }
            Console.WriteLine(stroka);
               
          



            

            Console.WriteLine("2 задание");

            Card card = new Card();
            card.ExpData = 1;
            card.Number = 1;
            card.Sum = 1;
            Card card2 = new Card();
            card2.ExpData = 3;
            card2.Number = 3;
            card2.Sum = 3;
            Card card3 = new Card();
            card3.ExpData = 2;
            card3.Number = 2;
            card3.Sum = 2;
            Card card4 = new Card();
            card4.ExpData = 5;
            card4.Number = 5;
            card4.Sum = 5;
            Card card5 = new Card();
            card5.ExpData = 4;
            card5.Number = 4;
            card5.Sum = 4;
            Card[] mass = {card,card2, card3, card4,card5 };
            card.Sort(mass);

        }
    }
}

