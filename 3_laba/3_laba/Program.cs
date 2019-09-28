using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_laba
{
    class Book
    {
        int id;
        string name;
        string Author;
        string Izdat;
        int age;
        int str;
        double price;
        string TypePereplet;
        public Book()
        {

        }
        public void GetInfo()
        {
            Console.WriteLine($"Id: {id}, Название: {name}, Автор: {Author}, Издательство: {Izdat}, Год: {age}, Количество страниц: {str}, Цена: {price}, Тип переплёта: {TypePereplet}");
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Book first = new Book();
            first.GetInfo();

        }
    }
}
