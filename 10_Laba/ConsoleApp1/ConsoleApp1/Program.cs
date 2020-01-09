using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static System.Console;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace ConsoleApp1
{
    class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Student(int age, string name)
        {
            Age = age;
            Name = name;

        }
    }
    class Program
    {
        private static void CollectionChanged(object sender,NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                        WriteLine($"Добавлен новый объект!");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    WriteLine($"Удален объект");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n ------------ 1 ЗАДАНИЕ ------------");
            ArrayList list = new ArrayList();
            Student pers1 = new Student(18,"Artem");
            list.Add(2);
            list.Add(9);
            list.Add(14);
            list.Add(37);
            list.Add(19);
            list.Add("Строка");
            list.Add(pers1);
            foreach(object x in list)
            {
                Console.WriteLine(x);
            }
            WriteLine($"Количество объеквтов листе  = {list.Count}");
            list.Remove("Строка");
            WriteLine();
            WriteLine("------------ УДАЛИЛ ИЗ СПИСКА СТРОКУ ------------");
            foreach (object x in list)
            {
                WriteLine(x);
            }
           WriteLine($"Количество объеквтов листе  = {list.Count}");

           

            Console.WriteLine("\n ------------ 2 ЗАДАНИЕ ------------");
            LinkedList<char> link = new LinkedList<char>();
            link.AddFirst('П');
            link.AddLast('Р');
            link.AddLast('И');
            link.AddLast('В');
            link.AddLast('Е');
            link.AddLast('Т');
            link.AddLast(' ');
            link.AddLast('M');
            link.AddLast('A');
            link.AddLast('N');


            Console.WriteLine("Изначальная коллекция");
            foreach(object x in link)
            {
                Console.Write(x);
            }
            Console.WriteLine();
            
            Console.WriteLine("Преобразованная  коллекция");
            for(int i = 0; i<4; i++)
            {
               link.RemoveLast();
            }

            foreach (object x in link)
            {
                Console.Write(x);
            }
            Console.WriteLine();
            Console.WriteLine("\n -------------- Использовал все возможные методы добавления для моего типа коллекции --------------");
            var after =  link.AddLast('?');
            var before = link.AddFirst('!');
            link.AddAfter(after, 'Z');
            link.AddBefore(before,'#');
            foreach (object x in link)
            {
                Console.Write(x);
            }
            Console.WriteLine();

            Console.WriteLine("--------------Создал вторую колекцию-----------");
            HashSet<char> has = new HashSet<char>();
           
            
            foreach (char x in link)
            {
                has.Add(x);
            }            foreach (char x in has)
            {
                Console.Write(x);
            }
            Console.WriteLine();

            WriteLine("Напищите, какой символ вы хотите найти в колекции");
            string input = ReadLine();
            char inp = char.Parse(input);
            bool flag = true;
            foreach(char x in has)
            {
                if(inp == x)
                {
                    WriteLine("Да, такой символ есть в колекции");
                    flag = false;
                }
               
            }
            if(flag == true)
            {
                WriteLine("Увы, такого символа нет в колекции");
            }

            WriteLine("------------ 3 Задание ---------------");

            Student stud1 = new Student(18, "Artem");
            Student stud2 = new Student(15, "Dima");
            Student stud3 = new Student(24, "Nikita");

            List<Student> list2 = new List<Student>();

            list2.Add(stud1);
            list2.Add(stud2);
            list2.Add(stud3);
            foreach(Student obj in list2)
            {
                WriteLine($"Возраст: {obj.Age}  Имя:{obj.Name}");
            }

            HashSet<Student> has2 = new HashSet<Student>();

            WriteLine("ПЕРЕНЕС ИЗ ОДНОЙ КОЛЕКЦИИ В ДРУГУЮ ИНФОРМАЦИЮ");
            foreach(Student x in list2)
            {
                has2.Add(x);
                WriteLine($"Возраст: {x.Age} Имя:{x.Name}" );
            }

            WriteLine("Введите возраст который вы хотите проверить");
            int age = int.Parse(ReadLine());
            
            flag = true;
            foreach (Student x in has2)
            {
                if (age == x.Age)
                {
                    WriteLine("Да, такой возраст есть в колекции");
                    flag = false;
                }

            }
            if (flag == true)
            {
                WriteLine("Увы, такого возраста  нет в колекции");
            }

            WriteLine("------------ 4 Задание ---------------");
            var obsev = new ObservableCollection<Student>();
            obsev.CollectionChanged += CollectionChanged;
            obsev.Add(stud1);
            obsev.Add(stud2);
            obsev.Remove(stud1);
           
        }
       


    }
}

