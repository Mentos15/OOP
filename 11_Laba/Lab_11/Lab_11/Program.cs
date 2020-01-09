using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lab_11
{

    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    partial class Book
    {
       
        string name;
        string Author;
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
   

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("--------- 1 ЗАДАНИЕ ---------");
            string[] mass = {  "December", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November" };
            WriteLine("Введите длинну месяцы(количество букв)");
            int str = int.Parse(ReadLine());
            

            WriteLine("\n-----------ЗАПРОС ВЫВОДИТ МЕСЯЦЫ ПО ДЛИННЕ СТРОКИ-----------\n");

            IEnumerable<string> result1 = mass.Where(n => n.Length == str);
            foreach (string x in result1)
            {
                Write(x+" ");
            }
            WriteLine();
            WriteLine("\n----------- ЗАПРОС ВЫВОДИТ ЗИМНИЕ И ЛЕТНИЕ МЕСЯЦЫ -----------\n");

            var result2 = mass.Where(n => (n.StartsWith("Au")) || (n.StartsWith("J")) || (n.StartsWith("De")) ||(n.StartsWith("F")));
            foreach (string x in result2)
            {
                Write(x+"  ");
            }
            WriteLine();
            WriteLine("\n ----------- ЗАПРОС ВЫВОДИТ МЕСЯЦЫ В АЛФАВИТНОМ ПОРЯДКЕ ----------- \n");
            var result3 = mass.OrderBy(n=>n);

            foreach (string x in result3)
            {
                Write($"{x}  ");
            }
            WriteLine();

            WriteLine("\n ----------- ЗАПРОС ВЫВОДИТ МЕСЯЦЫ СОДЕРЖАЩИЕ БУКВУ 'U' ----------- \n");
            var result4 = mass.Where(n => (n.Contains("u")) && (n.Length >= 4));

            foreach (string x in result4)
            {
                Write($"{x}  ");
            }

           

            


            WriteLine("\n--------- 3 ЗАДАНИЕ и 2 ЗАДАНИЕ---------");

            List<Book> list = new List<Book>();
            list.Add(new Book("Рассказы", "Булгаков", 2015, 211, 21));
            list.Add(new Book("Стихи", "Есенин", 2009, 156, 48));
            list.Add(new Book("Сказки", "Пушкин", 1999, 428, 86));
            list.Add(new Book("Басни", "Достоевский", 1990, 843, 54));
            list.Add(new Book("Песни", "Толстой", 2013, 37, 12));
            list.Add(new Book("Поэммы", "Грибоедов", 2003, 727, 122));

            list.Add(new Book("Рассказы", "Булгаков", 2015, 87, 21));
            list.Add(new Book("Стихи", "Есенин", 2009, 333, 48));
            list.Add(new Book("Сказки", "Пушкин", 1999, 68, 86));
            list.Add(new Book("Басни", "Достоевский", 1990, 734, 54));
            list.Add(new Book("Песни", "Толстой", 2013, 176, 12));
            list.Add(new Book("Поэммы", "Грибоедов", 2003, 522, 122));

            WriteLine("Введите имя автора");
            string auth = ReadLine();

            var res2 = from qq in list where qq.AUTHOR == auth  select qq;

            WriteLine("\n ----------- Книги заданного автора -----------");
            foreach (Book x in res2)
            {
                WriteLine($"{x.Name}");
            }

            WriteLine();
            WriteLine(" ----------- Введите год выпуска книги книги -----------");
            int age = int.Parse(ReadLine());

            var res3 = from qq in list where qq.AGE > age select qq;
            WriteLine($"Книги вышедшие после {age} года:");
            foreach (Book x in res3)
            {
                WriteLine( x.Name + $" \t Автор: {x.AUTHOR}");
            }

            WriteLine();
            var res4 = list.OrderBy(n => n.STR).Take(1).Select(n =>n);
            WriteLine("----------- Самая тонкая книга -----------\n");
            foreach (Book x in res4)
            {
                WriteLine("   Название: {0} - Количество страниц:{1}", x.Name, x.STR);
            }

            WriteLine();
            var res5 = list.OrderByDescending(n => n.STR).Take(5).Select(n => n);
            WriteLine("----------- 5 Самых толсных книг -----------\n");
            foreach (Book x in res5)
            {
                WriteLine("   Название: {0} - Количество страниц:{1}", x.Name, x.STR);
            }

            WriteLine();
            var res6 = list.OrderBy(x => x.PRICE);
            WriteLine("-----------Книги отсоритованы по цене-----------\n");
            foreach (Book x in res6)
            {
                WriteLine("   Название: {0} - цена:{1}", x.Name, x.PRICE);
            }
        
            WriteLine("------------------------------");

            WriteLine("\n--------- 4 ЗАДАНИЕ ---------");
            string[] mass2 = { "Понедельник", "Вторник", "Среда","Четверг","Пятница","Суббота","Воскресенье" };

            WriteLine("\nВывожу массив дней где длинна < 8");
            IEnumerable<string> out1 = mass2.Where(n => n.Length < 8);
            foreach (string x in out1)
            {
                Write(x + " ");
            }
            WriteLine();

            WriteLine("\nВывожу дни недели начинающиеся с буквы 'С' или 'В'");
            IEnumerable<string> out2 = mass2.Where(n => (n.StartsWith("С")) || (n.StartsWith("В")));
            foreach (string x in out2)
            {
                Write(x + " ");
            }
            WriteLine();
            WriteLine("\nВывожу количиско букв в каждом дне недели");
            IEnumerable<int> out3 = mass2.Select(n => n.Length);
            foreach (int x in out3)
            {
                Write(x + " ");
            }
            WriteLine();

            WriteLine("\nВывожу первые 3 дня");
            IEnumerable<string> out4 = mass2.Take(3);
            foreach (string x in out4)
            {
                Write(x + " ");
            }
            WriteLine();
            WriteLine("\nВывожу первый и последний дни");
            IEnumerable<string> out5 = mass2.Take(1).Concat(mass2.Skip(6));
            foreach (string x in out5)
            {
                Write(x + " ");
            }
            WriteLine();

            WriteLine("--------- 5 ЗАДАНИЕ ---------");

            List<Team> teams = new List<Team>()
            {
                 new Team { Name = "Terrorist", Country ="USA" },
                 new Team { Name = "Conter-Terrorist", Country ="Russia" }
            };
            List<Player> players = new List<Player>()
            {
                 new Player {Name="Spec1", Team="Conter-Terrorist"},
                 new Player {Name="Spec2", Team="Conter-Terrorist"},
                 new Player {Name="Teror1", Team="Terrorist"}
            };

             var result = players.Join(teams, p => p.Team, t => t.Name, (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country }); 

            foreach (var item in result)
            {
                WriteLine($"{item.Name} - {item.Team} ({item.Country})");
            }
            WriteLine();

        }
    }
}
