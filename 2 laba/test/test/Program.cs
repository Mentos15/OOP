using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace test
{
    class Person
    {
        public string Name;
        public string Age; 
        public Person(string name, string age)
        {
            Name = name;
            Age = age;
        }

    }

    class Example : IDisposable
    {
        private readonly int _state = 5;
     
        public Example(int state)
        {
            _state = state;

        }
        
        public int GetState() => _state;

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        
    }

    class Program
    {
        //    static void Main(string[] args)
        //    {

        //        string MyName = "Vitali";
        //        int MyVariant = 6;
        //        int y = 10;
        //        string str = "Hello";
        //        Console.WriteLine("Задание 1");
        //        // №1
        //        Object o = y;   // упаковка y; o ссылается на упакованный объект
        //        int y2 = (int)o; // распаковка o  в y2

        //        Object q = str;
        //        string str2 = (string)q;

        //        // №2
        //        Console.WriteLine("Задание 2");
        //        long lo = MyVariant; // неявное
        //        float fl = MyVariant; // неявное
        //        double dobl = MyVariant; // неявное

        //        byte by = (byte)MyVariant; // явное
        //        short sh = (short)MyVariant;    // явное
        //        char ch = (char)MyVariant; // явное

        //        // №3
        //        Console.WriteLine("Задание 3");
        //        string method = String.Format("My name is {0} ", MyName);
        //        string method2 = $"My name is {MyName}";

        //        // №4
        //        Console.WriteLine("Задание 4");
        //        Console.WriteLine(MyVariant.ToString()); // Метод ToString для получения строкового представления данного объекта
        //        Person person = new Person ("Vitali", "18" );
        //        Person chel = new Person ( "Artem",  "18" );
        //        Console.WriteLine(person.GetType()); // Получаем тип данного объекта(Person)
        //        Console.WriteLine(person.GetHashCode()); // получаем хеш
        //        Console.WriteLine(person.Name.Equals(chel.Name));// сравнивнение объектов на равенство

        //        // №5
        //        Console.WriteLine("Задание 5");
        //        string first = "one two tree ";
        //        string second = "two";
        //        string plus = "four";
        //        Console.WriteLine(String.Compare(first, second)); // если первая строка больше второй то возвращает 1, если наоборот то -1, если они равны то 0



        //        bool test = first.Contains(second); // Contains - проверяет встречается ли слово(буква) second в строке first
        //        Console.WriteLine(test);

        //        string str3 = first.Substring(3, 5); // обрезаем определенную часть строки
        //        Console.WriteLine(str3);

        //        first = plus.Insert(0, first); // втсавляю строку plus(с нулевого элемента) в строку first
        //        Console.WriteLine(first);

        //        first = first.Replace("four", "five"); // заменяю в строке first four на five
        //        Console.WriteLine(first);

        //        // №6
        //        Console.WriteLine("Задание 6");
        //        string str4 = "";
        //        string str5 = null;
        //        string str6 = "text";
        //        Console.WriteLine(string.IsNullOrEmpty(str4));
        //        Console.WriteLine(string.IsNullOrEmpty(str5));
        //        Console.WriteLine(string.IsNullOrEmpty(str6));

        //        // №7

        //        //var varriable = "";
        //        //varriable = 5;

        //        // №8
        //        int? qw = null;

        //        // СРЕДНИЙ УРОВЕНЬ

        //        // №1
        //        Console.WriteLine(" Средний Уровень Задание 1");
        //        void LocFun((int a, int b) qhw)
        //        {
        //            Console.WriteLine(qhw);
        //        }
        //        LocFun((3, 8));

        //        // №2
        //        Console.WriteLine(" Средний Уровень Задание 2");
        //        var info = (name: "Vitali", age: 18, univer: "BSTU");

        //        var one = info.name;
        //        var two = info.age;
        //        var tree = info.univer;

        //        Console.WriteLine($"{one} {two} {tree}");

        //        string onee = info.name;
        //        int twoo = info.age;
        //        var treee = info.univer;

        //        Console.WriteLine("{0} {1} {2}", onee, twoo, treee);

        //        // №3
        //        Console.WriteLine(" Средний Уровень Задание 3");
        //        void loc1()
        //        {
        //            checked
        //            {
        //                //int max = 2147483647 + 1;
        //                //WriteLine(max);
        //            }
        //        }
        //        void loc2()
        //        {
        //            unchecked
        //            {
        //                int max2 = 2147483647 + 1;
        //                WriteLine(max2);
        //            }
        //        }
        //        loc1();
        //        loc2();
        //        Console.WriteLine(" Повышенный Уровень Задание 1");
        //        using (Example ex = new Example(7))
        //        {
        //            WriteLine(ex.GetState());
        //        };



        //    }
        //}

        static void Main(string[] aargs)
        {

            int[,] c = new int[2, 3] { { 2, -1, 8 }, { 7, 2, -4 } };
            int i = 0;
            foreach (int s in c)
            {
                Write(s + " ");
                i++;
                if (i % 3 == 0)
                {
                    WriteLine();
                    i = 0;
                }
            }
        }

    }
}
