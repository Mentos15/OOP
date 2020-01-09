using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Console;

namespace LAB_12
{
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    partial class Book : IEnumerator
    {

        public string name;
        public string Author;
        int age;
        int str;
        float price = 102;

        public static int schet = 0;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string AUTHOR
        {
            get { return Author; }
            set { Author = value; }

        }

        public int AGE
        {
            get { return age; }
            set { age = value; }
        }
        public int STR
        {
            get { return str; }
            set
            {
                if (value < 1)
                {
                    str = -1;
                }
                else
                {
                    str = value;
                }
            }
        }
        public float PRICE
        {
            get { return price; }
            private set { price = value; }
        }



        public Book(string name, string Author, int age, int str, float price)
        {

            this.name = name;
            this.Author = Author;
            if (age > 2019)
            {
                WriteLine("Неверно указан год");
            }
            else
            {
                this.age = age;
            }
            this.str = str;
            this.price = price;

            schet++;

        }
    }

    internal interface IEnumerator
    {
    }

    public class Person : IComparable
    {
        public string name;
        public int age;

        public string NAME { get; set; }

        public int Method(int x)
        {
            x = x * x;
            return x;
        }
        public string stroka(string str)
        {
            return "Stroka";
        }

        public string Strokoviy(string str)
        {
            return "Stroka";
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    public class Reflector
    {

        public void WriteConsol(Type t)
        {
            
            WriteLine("---------- Доступные поля класса ------------");
            foreach (FieldInfo x in t.GetFields())
            {
                WriteLine("- " + x.Name);

            }

            WriteLine("\n --------------- Метод который можно использовать с классом -------------");
            foreach (MethodInfo x in t.GetMethods())
            {
                WriteLine("-  " + x.Name);
            }
            WriteLine("\n --------------- Свойства класса-------------");
            foreach (PropertyInfo x in t.GetProperties())
            {
                WriteLine("-  " + x.Name);
            }

            WriteLine("\n --------------- Реализуемые интерфейсы -------------");
            foreach (Type x in t.GetInterfaces())
            {
                WriteLine("-  " + x.Name);
            }

            
            
        }


        public void Writefile(Type t)
        {

            var file = new StreamWriter("out.txt", false);
            file.WriteLine("---------- Поля класса ------------");
            foreach (FieldInfo x in t.GetFields())
            {
                file.WriteLine("- " + x.Name);

            }

            file.WriteLine("\n --------------- Метод который можно использовать с классом -------------");
            foreach (MethodInfo x in t.GetMethods())
            {
                file.WriteLine("-  " + x.Name);
            }

            file.WriteLine("\n --------------- Реализуемые интерфейсы -------------");
            foreach (Type x in t.GetInterfaces())
            {
                file.WriteLine("-  " + x.Name);
            }

            file.Close();
            WriteLine("Загляните в файл");
        }
        public List<string> Getmethods (Type l)
        {
            List<string> list = new List<string>();
            foreach (MethodInfo x in l.GetMethods())
            {
                list.Add(x.Name);
            }

           
            return list;
        }
        public List<string> Getinterface(Type l)
        {
            List<string> list = new List<string>();
            foreach (Type x in l.GetInterfaces())
            {
                list.Add(x.Name);
            }


            return list;
        }

        public void GetPolAndSv(Type p)
        {
            WriteLine("------------ Доступные поля в классе ------------ ");
            foreach (FieldInfo x in p.GetFields())
            {
                WriteLine(x.Name);
            }
            WriteLine("------------ Доступные свойства классе ------------ ");
            foreach (PropertyInfo x in p.GetProperties())
            {
                WriteLine(x.Name);
            }
        }
        public List<string> GetMethodsParm(Type p)
        {
            List<string> list = new List<string>();

            Reflector qqq = new Reflector();
            string z = "System.";
            z += ReadLine();
            
            foreach (MethodInfo x in p.GetMethods())
            {
                foreach (ParameterInfo y in x.GetParameters())
                {
                    if (Type.GetType(z) == y.ParameterType) // можно вставить любой тип 
                    {
                        WriteLine(" - " + x.Name);
                    }

                }
            }

            return list;
        }

        public void QQQ(string cl, string met)
        {
            
            
        }

        public int OUT(int x, int y)
        {

            
            return x * y;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Reflector reff = new Reflector();
            WriteLine("-------A--------- Вывести в файл всю инфу о классе  ----------------");
            reff.Writefile(typeof(Person));

            WriteLine("-------B--------- Все общедоступные публичные методы  ----------------");
            foreach(string x in reff.Getmethods(typeof(Person)))
            {
                WriteLine(" - " + x);
            }
            WriteLine("-------C--------- Все полня и свойства содержащиеся в классе  ----------------");

            reff.GetPolAndSv(typeof(Person));

            WriteLine("-------D--------- Все реализованные классом интерфейсы  ----------------");
            foreach (string x in reff.Getinterface(typeof(Person)))
            {
              WriteLine(" - " + x);
            }

           
            WriteLine("-------E--------- Вывести имена методов, которые содержат заданный тип параметра ----------------");
            reff.GetMethodsParm(typeof(Person));

            WriteLine("-------F--------- Вызов некоторого метода из указанного ----------------");


            string path = @"C:\Users\Виталий\ООП\12_Laba\LAB_12\LAB_12\Вызов.txt";
            int par1;
            int par2;
            using (StreamReader sr = new StreamReader(path))
            {
                par1 = int.Parse(sr.ReadLine());
                par2 = int.Parse(sr.ReadLine());

                WriteLine("Функция вернула число = "+reff.OUT(par1, par2));

            }

            WriteLine("************ Информация о классах из прошлой лабораторки ************ ");

            WriteLine("==== Информация о классе Book ===");
            reff.WriteConsol(typeof(Book));

            WriteLine("==== Информация о классе Player ===");
            reff.WriteConsol(typeof(Player));

            WriteLine("==== Информация о классе Console ===");
            reff.WriteConsol(typeof(Console));






        }
    }
}
