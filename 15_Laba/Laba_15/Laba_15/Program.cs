using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Threading;

namespace Laba_15
{
    class Program
    {

        public class THREAD
        {
            static object locker = new object();
            public Thread myThread;
            public Thread myThread1;
            public int Num { get; set; }
            public THREAD(int num)
            {
                myThread = new Thread(this.Even);
                myThread1 = new Thread(new ThreadStart(this.Odd)) { Priority = ThreadPriority.AboveNormal };
                Num = num;
            }
            public void Count(object obj)
            {
                int x = (int)obj;
                for (int i = 1; i < 9; i++, x++)
                {
                    Console.WriteLine(x * i);
                }
            }

            public void Even()
            {
                for (int i = 0; i < Num; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i + " ");
                    }
                    Thread.Sleep(500);
                }
            }
            public void Odd()
            {
                for (int i = 0; i < Num; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.Write(i + " ");
                    }
                    Thread.Sleep(500);
                }
            }
        }

        public static void Num()
        {
            try
            {
                Console.WriteLine("\nВведите количество чисел");
                int m = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[m];
                int s = 0, k;
                arr[s++] = 1;
                for (int i = 2; i <= m; i++)
                {
                    k = 0;
                    for (int j = 2; j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            k += 1;
                        }
                    }
                    if (k == 1)
                    {
                        arr[s++] = i;
                    }
                }
                for (int i = 0; i < s; i++)
                {
                    Console.WriteLine(arr[i] + " ");
                    using (StreamWriter file = new StreamWriter("C:\\Users\\Виталий\\ООП\\15_Laba\\NUMBERS.txt", true, System.Text.Encoding.Default))
                    {
                        file.WriteLine(arr[i] + " ");
                    }
                    Thread.Sleep(500);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            
                using (StreamWriter sw = new StreamWriter("C:\\Users\\Виталий\\ООП\\15_Laba\\INFO.txt"))
                {
                    Process[] allProcess = Process.GetProcesses();
                    foreach (Process proc in allProcess)
                    {
                        if (proc.ProcessName != "Idle")
                        {
                            sw.WriteLine("Id: " + proc.Id);
                            sw.WriteLine("Process name: " + proc.ProcessName);
                        try
                        {
                            sw.WriteLine("Start at: " + proc.StartTime);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        sw.WriteLine();
                        }
                    }
                }



            using (StreamWriter sw = new StreamWriter("C:\\Users\\Виталий\\ООП\\15_Laba\\DOMAIN.txt"))
            {
                Console.WriteLine("\nDOMAIN: ");
                AppDomain domain = AppDomain.CurrentDomain;
                Console.WriteLine("Name: " + domain.FriendlyName + "\nConfiguration: " + domain.SetupInformation.ConfigurationFile);
                Console.WriteLine("Assemblies: ");
                foreach (Assembly ass in domain.GetAssemblies())
                {
                    sw.WriteLine(ass);
                }
            }


            Console.WriteLine("\nPrime number: ");
            Thread thread = new Thread(Num);
            thread.Start();
            Console.WriteLine("Thread is " + thread.ThreadState);
            thread.Name = "Write numbers in file and console";
            Console.WriteLine("Name: " + thread.Name + "\nPriority: " + thread.Priority + "\nStatus: " + thread.ThreadState + "\nId: " + thread.ManagedThreadId);
            thread.Join();



            Console.WriteLine("\n\nЧетные и нечетные");
            THREAD th = new THREAD(10);
            th.myThread.Start();
            th.myThread.Join();
            th.myThread1.Start();
            th.myThread1.Join();
            Console.WriteLine();
            THREAD th1 = new THREAD(10);
            th1.myThread.Start();
            th1.myThread1.Start();
            th1.myThread.Join();
            th1.myThread1.Join();
            Console.WriteLine();


            int num = 10;
            TimerCallback tm = new TimerCallback(th.Count);
            Timer timer = new Timer(tm, num, 150, 10000);

            Console.ReadLine();
        }
    }
}
