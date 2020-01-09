using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace _3_laba
{   
    partial class Book
    {
        int id;
        string  name ;
        string Author ;
        const string Izdat = "Belorusochka";
        int age;
        int str;
        float price = 102;
        readonly string TypePereplet = "Книжный";
        public static int schet = 0;

        public int Id
        {
            get;set;
        }
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
        public string IZDAT
        {
            get { return Izdat; }
        }
        public int AGE
        {
            get { return age; }
            set { age = value; }
        }
        public int STR
        {
            get { return str; }
            set {
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
        public string TYPEPEREPLET
        {
            get { return TypePereplet; }
        }
        public Book()
        {
            id = 0;
            name = "Noname";
            Author = "Noname";
            age = 0;
            str = 0;
            price = 0;
            schet++;
 
        }
        static Book()
        {
            schet = 0;
            
        }
        private Book(int id)
        {
            this.id = id;
        }
        public Book(int id,string name,  string Author, int age, int str, float price)
        {
            this.id = id;
            this.name = name;
            this.Author = Author;
            if (age>2019)
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
    partial class Book
    {
        public static int schetchik()
        {
            return schet;
        }
        public void First(out int id, ref string Author)
        {

            id = 18;
            Console.WriteLine($" Автор: {Author} \n Id: {id}\n");


        }
        public void DD(int a)
        {
            Console.WriteLine(a);
        }
        public string GetInfo()
        {
            return $"Id: {id} \n Название: {name}\n Автор: {Author}\n Издательство: {Izdat}\n Год: {age}\n Количество страниц: {str}\n Цена: {price}\n Тип переплёта: {TypePereplet}\n";

        }
        public static string Spisok(string inp, Book[] bookArray)
        {
            string list = String.Empty;
            foreach(Book b in bookArray)
            {
                if (inp == b.Author)
                    list += b.Name + "\n";
            }
            return list;
        }
        public static string SpisokAge(int temp, Book[] bookArray)
        {
            string listAge = String.Empty;
            foreach (Book b in bookArray)
            {
                if (temp < b.age)
                    listAge += b.Name + "\n";
            }
            return listAge;
        }

        // Переопредление
        public override int GetHashCode()
        {
            WriteLine("It's GetHashCode");
            return ((id*age*str+8)*32*+2121*age);
        }
        public override string ToString()
        {
            return GetInfo();
        }
        public override bool Equals(object obj)
        {
            WriteLine("Переопределил Equals");
            return base.Equals(obj);
        }
       

    }

    class Program
    {
        static void Main(string[] args)
        {
            int Gurid;
            string AVT = "Gurski";
            Book first = new Book();
            first.First(out Gurid, ref AVT);

            WriteLine("-------------------");

            Book two = new Book();
            two.STR = -211;
            

            Book three = new Book(2,"Artik","Gurski",3221,321,54);

            Console.WriteLine(three.AGE);

            Book four = new Book(3, "Поэмы" ,"Gurski", 2005, 251, 22);
            Book five = new Book(4, "Рассказы", "Surago", 14, 274, 48);
            Book six = new Book(5, "Стихи", "Gurski", 2017, 274, 48);
            Book seven = new Book(6, "Басни", "Gurski", 2012, 274, 48);

            Book[] mass = new Book[] { first,two,three,four,five,six};
            foreach(Book book in mass)
            {
                Console.WriteLine(book.GetInfo());
            }

            
            var std = new {Name="ASe",id=2 };  
            WriteLine(std.Name + " " + std.id);

            WriteLine("------Переопределение-----");
            WriteLine("---------------Equals----------");
            WriteLine(three.Equals(first));
            WriteLine("-----------GetHashCode-------------");
            WriteLine(three.GetHashCode());
            WriteLine("------------ToString----------");
            WriteLine(three.ToString());
            WriteLine("-------------------");


            WriteLine("Список по Автору:");
            WriteLine(Book.Spisok("Gurski",mass));
            WriteLine("-------------------");

            WriteLine("Список книг после указанного года:");
            WriteLine(Book.SpisokAge(2002, mass));
            WriteLine("-------------------");

            WriteLine("Количество сощданных объектов = " + Book.schet);

        }
             

    }
}
