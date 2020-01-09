using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Laba_16
{
    class Program
    {
        static Task<int> FactorialAsync(int x)
        {
            int result = 1;
            return Task.Run(() =>
            {
                
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                Thread.Sleep(2000);
                return result;
            });
        }
        static async Task DisplayResultAsync()
        {
            int result = await FactorialAsync(5);
            Console.WriteLine("Факториал числа {0} равен {1}", 5, result);
        }

        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        
        static CancellationToken token = cancelTokenSource.Token;
       
        static void Main(string[] args)
        {
            Console.WriteLine("------------ 1 и 2 ЗАДАНИЯ ---------------");
            Tasks.GetTask(1000000, 1);
            Tasks.GetTask(1000000, 2);
            Tasks.GetTask(1000000, 3);
            Task task = new Task(() =>
            {
                Tasks.GetTask(100000, 64);
                
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("IS Cancellation");
                }
            });

            Console.ReadKey();
            Console.WriteLine("------------ 3 и 4 ЗАДАНИЯ ---------------");
            Tasks.FourSum(new Vector(10), new Vector(20), new Vector(30)).GetAwaiter().GetResult();

            Console.ReadKey();
            Console.WriteLine("------------ 5 ЗАДАНИЕ ---------------");
            Paralleler.For();
            Paralleler.ForEach();

            Console.ReadKey();
            Console.WriteLine("------------ 6 ЗАДАНИЕ ---------------");
            Paralleler.DoubleTask(100000);

            Console.ReadKey();
            Console.WriteLine("------------ 7 ЗАДАНИЕ ---------------");
            Store.Work();

            Console.ReadKey();
            Console.WriteLine("------------ 8 ЗАДАНИЕ ---------------");
            Task t = DisplayResultAsync();
            t.Wait();
        }

    }
}
