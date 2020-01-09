using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Laba_4
{
    public class Node
    {
        public Node(int data)
        {
            Data = data;
           
        }
        public int Data { get; set; }
        public Node Next { get; set; }
    }
    public class List : IEnumerable
    {
        Node head;
        Node tail;
        int count;
        
        public Node Head { get { return head; } }

        public void Add(int data)
        {
            Node node = new Node(data);

            if (head == null)
            {
                head = node;
            }
            else
                tail.Next = node;
            tail = node;
            count++;
        }

        
        public bool Remove(int data)
        {
            Node current = head;
            Node previous = null;   // Для отслеживания предыдущего узла

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
            Node current = head;
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
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public static bool operator >>(List elem, int i)
        {
            return elem.Remove(i);
        }
        public static List operator +(List elem, int i)
        {
            elem.Add(i);
            return elem;
        }

        public static bool operator != (List first, List second)
        {
            int k = 0;
            foreach(int one in first)
            {
                foreach(int  two in second)
                {
                    if(one == two)
                    {
                        k++;
                        break;
                    }
                }
            }
            if(k==first.Count && k== second.count)
                return false;
            return true;

        }
        public static bool operator ==(List first, List second)
        {
            int k = 0;
            foreach (int one in first)
            {
                foreach (int two in second)
                {
                    if (one == two)
                    {
                        k++;
                        break;
                    }
                }
            }
            if (k == first.Count && k == second.count)
                return true;
            return false;
           
        }


        class Owner
        {
           int Id=5;
            string name = "Artem";
            string organ = "OAO Artik";

        }
        class Date
        {
            int day = 17;
            int month = 10;
            int year = 2019;
        }

    }
    
    static class StatisticOperation
    {
        public static int Sum(List inf)
        {
            int sum = 0;
            Node cur = inf.Head;
            while(cur!=null)
            {
                sum += cur.Data;
                cur=cur.Next;
            }
            return sum;
        }
        public static int Razn(List inf)
        {
            int max = inf.Head.Data;
            int min = inf.Head.Data;
            Node cur = inf.Head;
            while (cur != null)
            {
                if (cur.Data <= min)
                    min = cur.Data;
                if (cur.Data >= max)
                    max = cur.Data;
                cur = cur.Next;
            }
            return max-min;
        }
        public static int Schet(List inf)
        {
            int Schet = 0;
            Node cur = inf.Head;
            while (cur != null)
            {
                cur = cur.Next;
                Schet++;
            }
            return Schet;
        }
        public static string Dlina(this List dlinn)
        {
            
            string[] str=new string[10];
            int i = 0;
            Node cur = dlinn.Head;
            while (cur != null)
            {
                str[i] = cur.Data.ToString();
                cur = cur.Next;
                i++;
            }
            string max="";
            for(int k=0;k<i;k++)
            {
                if(string.Compare(str[k],str[k+1])==-1)
                {
                    max = str[k];
                    
                }
            }
            return max;

        }
        public static void DelLast(this List del)
        {
            int Schet = 0;
            Node cur = del.Head;
            while (cur != null)
            {
                cur = cur.Next;
                Schet++;
            }
            cur = del.Head;
            for(int i=0;i<Schet;i++)
            {
                cur = cur.Next;
                if(i==Schet-2)
                {
                    del.Remove(cur.Data);
                }
            }
        }
        public static bool IsLetter(this string lett,char a)        
        {
            bool flag = false;
            foreach(var st in lett)
            {
                if (st == a)
                    flag = true;
            }
            return flag;
        }
        public static string BigStr(this List qwe, string str)
        {
            string[] masss = str.Split(' ');
            int temp = masss[0].Length;
            string tempstr=masss[0];
            for(int i=0;i<masss.Length;i++)
            {
                if (masss[i].Length > temp)
                {
                    tempstr = masss[i];
                    temp = masss[i].Length;
                }

                

            }
            return tempstr;
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Первый список");
            List test = new List();
            test.Add(5);
            test.Add(6);
            test.Add(1);
            test.Add(12);
            test.Add(4);

            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            WriteLine("------------");
            WriteLine("Второй список");
            List test2 = new List();
            test2.Add(6);
            test2.Add(5);
            test2.Add(12);
            test2.Add(1);
            foreach (var item in test2)
            {
                Console.WriteLine(item);
            }
            WriteLine("------------");
            WriteLine("Первый список после удаления цифры 4");
            test.Remove(4);
            
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            WriteLine("------------");
            WriteLine("Удалил с помощью перегрузки >> элемент 5");
            Console.WriteLine(test >> 5);
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            WriteLine("------------");
            WriteLine("Добавил с помощью перегрузки + элемент 1");
            test = test + 20;
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            WriteLine("------------");
            WriteLine("Перегрузил оператор !=");
            WriteLine(test != test2);
            WriteLine("------------");

            //// проверяем наличие элемента
            //bool isPresent = test.Contains(10);
            //Console.WriteLine(isPresent == true ? "10 присутствует" : "10 отсутствует");
            
            WriteLine("Сумма всех элементов");
            WriteLine(StatisticOperation.Sum(test));
            WriteLine("Количество элементов в списке");
            WriteLine(StatisticOperation.Schet(test));
            WriteLine("-------------");
            WriteLine("Удалил последний элемент списка");
            test.DelLast();
            
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            WriteLine("-------------");
            WriteLine("Самое длинное слово в предложении  'hello yes qwertywq byeeee'");
            WriteLine(test.BigStr("hello yes qwertywq byeeee"));
          
            
        }
    }
}
