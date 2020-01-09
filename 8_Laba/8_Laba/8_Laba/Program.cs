using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _8_Laba
{
    public interface INTER<T>
    {
        void Add(T add);
        bool Del(T delete);
        void Info();

    }

    public class Node<T>
    {
        public Node(T data)
        {

          
            Data = data;

        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class CollectionType<T> : IEnumerable,INTER<T> /*where T : class*/
    {
        Node<T> tail;
        Node<T> head;
        int count;

        public Node<T> Head { get { return head; } }

        public void Add(T data)
        {
            if (count > 3)
            {
                throw new IndexOutOfRangeException("ВЫХОД ЗА ПРЕДЕЛЫ!!!");
            }
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
                tail.Next = node;
            tail = node;
            count++;
        }


        public bool Del(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;   // Для отслеживания предыдущего узла

            while (current != null)
            {
                if (current.Data.Equals(data))
                {

                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void Info()
        {
            Node<T> inf=Head;
            for (int i = 0; i < count; i++)
            {
                WriteLine($"{inf.Data}");
                inf = inf.Next;
                
            }
        }
        public int Count { get { return count; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // содержит ли список элемент
        public bool Contains(int data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void WriteFile()
        {
            Node<T> inf = Head;
            var file = new StreamWriter("out.txt", true);
            for (int i = count - 1; i >= 0; i--)
            {
                file.WriteLine(inf.Data);
                inf = inf.Next;
            }
                
            file.Close();
            Console.WriteLine("Загляните в файл");
        }
        public static void ReadFile()
        {
            var file = new StreamReader("out.txt");
            Console.WriteLine(file.ReadToEnd());
            file.Close();
        }

       

    }

    class Persona 
    {
        //public Persona() : base() { }
        public string Name { get; set; }
        
        public int Age { get; set; }
        public string FavoritJanr
        {
            get; set;
        }
        public Persona()
        {

        }
        public Persona(string favoritjanr, int age, string name)
        {
            FavoritJanr = favoritjanr;
            Age = age;
            Name = name;
        }
        
    }

    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                CollectionType<int> test = new CollectionType<int>();
                test.Add(5);
                test.Add(9);
                test.Add(2);
                test.Add(37);
                test.Add(80);
                CollectionType<char> test2 = new CollectionType<char>();
                CollectionType<float> test3 = new CollectionType<float>();
                CollectionType<bool> test4 = new CollectionType<bool>();
                //CollectionType<string> test5 = new CollectionType<string>0);

                CollectionType<Persona> test6 = new CollectionType<Persona>();
                Persona pers1 = new Persona("weq",15,"Artik");
                Persona pers2 = new Persona();
                test6.Add(pers1);
                test6.Info();

                test.Info();

                test.WriteFile();

                WriteLine();
                //CollectionType<int>.ReadFile();
            }
            catch (IndexOutOfRangeException t)
            {
                WriteLine(t.Message);
            }
            finally
            {
                WriteLine("Блок finaly сработал");
            }
           
            
        }
    }
}
