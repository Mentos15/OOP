using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using System.Collections;

namespace Laba_5
{
    interface Interface
    {
        string Print();
    }
    public abstract class Abstrct
    {
       public abstract string Info();
    }
    interface Interface2
    {
        string Sort(object[] objj);
    }
    public abstract class Abstrct2
    {
        
        public int ColStr
        {
            get; set;
        }
        public abstract string Sort(object[] objj);
    }
     class Jurnal:Book
    {
        

        
        public string Type{get;set;}
            

        public Jurnal(int colstr,string name,string type)
        {
            ColStr = colstr;
            Name = name;
            Type = type;
        }
        public Jurnal()
        {

        }
        public override string ToString()
        {
            return ($" Количество страниц: {ColStr} \n Название журнала: {Name} \n Тип журнала: {Type}");
        }

       
    }
    class Book:Uchebnik
    {
       
        
        public string Name { get; set; }
        public string Janr { get; set; }
        public int Year { get; set;  }

        public Book()
        {

        }
        public Book(int colstr,string name,string janr, int year)
        {
            ColStr = colstr;
            Name = name;
            Janr = janr;
            Year = year;
        }
        public override string ToString()
        {
            return ($" Количество страниц: {ColStr} \n Название книги: {Name} \n Жанр: {Janr} \n Год выпуска: {Year}");
        }

    }
    sealed class PechatnoeIzdanie
    {
      
        public string Book
        {
            get;set;
        }
        public string Jurnal
        {
            get;set;
        }
        public string Uchebnik
        {
            get;set;
        }
        public PechatnoeIzdanie()
        {

        }
        public PechatnoeIzdanie(string book,string jurnal, string uchebnik)
        {
            Book = book;
            Jurnal = jurnal;
            Uchebnik = uchebnik;
        }
        public override string ToString()
        {
            return($"Название книги: {Book} \n Название журнала:{Jurnal} \n Название учебника:{Uchebnik}"); 
        }
    }
    class Uchebnik:Biblioteka,Interface2
    {
        public static int count = 0;

        
        public string Pereplet
        {
            get;set;
        }
        public string Predmet
        {
            get;set;
        }
       
        
        public Uchebnik()
        {

        }
        public Uchebnik(string pereplet, string predmet, int colstr)
        {
            Pereplet = pereplet;
            Predmet = predmet;
            ColStr = colstr;
            count++;
        }
       
        public override string ToString()
        {
            return ($"Переплет: {Pereplet} \n Предмет {Predmet} \n Количество страниц: {ColStr}");
        }

        string Interface2.Sort(object[] objj)
        {
            Uchebnik[] obj = (Uchebnik[])objj;
            Uchebnik vrem;
            string mass2 = "";
            for (int i = 0; i < obj.Length; i++)
            {
                for (int j = 0; j < obj.Length; j++)
                {
                    if (obj[i].ColStr < obj[j].ColStr)
                    {
                        vrem = obj[i];
                        obj[i] = obj[j];
                        obj[j] = vrem;
                    }
                }
            }
            for (int i = 0; i < obj.Length; i++)
            {

                WriteLine(obj[i]);
                WriteLine("_____________________");
            }
            return mass2;
        }

       
    }
    class Persona : Author
    {
        private Telo telo = new Telo();
        public struct Telo
        {
            public string Head;
            public string Hand;
            public string Body;
            public string Eyes;

        }
        public void DoPerson(string head,string hand,string body, string eyes)
        {
            telo.Head = head;
            telo.Hand = hand;
            telo.Body = body;
            telo.Eyes = eyes;
        }
        public string InfoPerson()
        {
            return ($"Ваш человек состоит из: \n {telo.Head} \n { telo.Hand} \n { telo.Body} \n {telo.Eyes}");
        }
        
        public string FavoritJanr
        {
            get;set;
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
        public override string GetInfo()
        {
            return($"Предпочитаемый жарн: {FavoritJanr} \n Возраст: {Age} \n Имя: {Name}");
        }
    }

    
    class Izdatelstvo:Abstrct2,Interface2
    {
       
        public string City{ get; set; }
        public int ColBook{ get; set; }
        public string Name{ get; set; }

        public Izdatelstvo(string city,int colbook,string name)
        {
            City = city;
            ColBook = colbook;
            Name = name;

        }
        public Izdatelstvo()
        {

        }
        public override int GetHashCode()
        {
            return ColBook*12817913;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Izdatelstvo m = obj as Izdatelstvo; // возвращает null если объект нельзя привести к типу Money
            if (m as Izdatelstvo == null)
                return false;

            return m.City == City && m.ColBook == ColBook;
        }
        public override string ToString()
        {
            return ($"Город:{City} \n Количество книг: {ColBook} \n Название издательства: {Name}");
        }

        string Interface2.Sort(object[] objj)
        {
            Izdatelstvo[] obj = (Izdatelstvo[])objj;
            Izdatelstvo vrem;
            string mass2 = "";
            for (int i = 0; i < obj.Length; i++)
            {
                for (int j = 0; j < obj.Length; j++)
                {
                    if (obj[i].ColBook < obj[j].ColBook)
                    {
                        vrem = obj[i];
                        obj[i] = obj[j];
                        obj[j] = vrem;
                    }
                }
             }
            for (int i = 0; i < obj.Length; i++)
            {

                WriteLine(obj[i]);
                WriteLine("_____________________");
            }
            return mass2;
        }

        public override string Sort(object[] objj)
        {
            Izdatelstvo[] obj = (Izdatelstvo[])objj;
            Izdatelstvo vrem;
            string mass2="";
            for (int i = 0; i < obj.Length; i++)
            {
                for(int j=0;j<obj.Length;j++)
                {
                    if (obj[i].ColBook > obj[j].ColBook)
                    {
                        vrem = obj[i];
                        obj[i] = obj[j];
                        obj[j] = vrem;
                    }
                }
               
            }
            for(int i=0;i<obj.Length;i++)
            {
                
                WriteLine(obj[i]);
                WriteLine("_____________________");
            }
            return mass2;
        }
    }
    class Printer:Biblioteka
    {
        enum Format
        {
            A1 = 1,
            A2 = 2,
            A3 = 3,
            A4 = 4

        }
        Format form = new Format();

        public  Printer(int format)
        {
            
            if(format == 1)
            {
                form = Format.A1;
            }
            else if (format == 2)
            {
                form = Format.A2;
            }
            else if (format == 3)
            {
                form = Format.A3;
            }
            else  if (format == 4)
            {
                form = Format.A4;
            }
            else
            {
                WriteLine("Данный тип бумаги не вохможно распечатать");
            }
            
        }

        public virtual void IAmPrinting(Abstrct2 obj)
        {
            WriteLine(obj.GetType());
            WriteLine(obj.ToString());
            WriteLine("_____________________");

        }
        public string GetInfo()
        {
            
            return ($"Формат распечатки = {form}");
        }

       
    }

    // для 6 лабы
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            
            Interface2 interf = new Izdatelstvo("Minsk",18,"Союз Печать");
            Abstrct2 abstr = new Izdatelstvo("Minsk", 33, "Лидер Пресс");

            Izdatelstvo izdat = new Izdatelstvo("Minsk", 18, "Союз Печать");
            Izdatelstvo izdat2 = new Izdatelstvo("Minsk", 33, "Лидер Пресс");
            Izdatelstvo izdat3 = new Izdatelstvo("Minsk", 7, "Белочка");
            Izdatelstvo izdat4 = new Izdatelstvo("Minsk", 20, "Белорусочка");
            Izdatelstvo[] mass = { izdat, izdat2, izdat3, izdat4 } ;
            WriteLine("-------4 задание-----");
            WriteLine("________По Возрастанию с помощью интерфеса_____________");
            WriteLine(((Interface2)izdat3).Sort(mass));
            WriteLine("________По убыванию с помощью абстр класса_____________");
            WriteLine(izdat3.Sort(mass));

            WriteLine("-------1 задание-----");
            Author auth = new Author("Artem", 84, "Стихи");
            WriteLine(auth.GetInfo());
            WriteLine("_____________________");
            WriteLine("Хеш код:" + izdat.GetHashCode());
            WriteLine(izdat.ToString());
            WriteLine("-----Сравниваю 2 объекта по городу и количеству книг");
            WriteLine(izdat.Equals(izdat2));
            WriteLine("_____________________");

            Persona pers = new Persona();

            Jurnal jurn = new Jurnal(82,"Мода", "Глянцевый");
            WriteLine("-------5 задание-----");
            WriteLine("______IS_________");
            bool chek = pers is Author;
            WriteLine(chek);
            bool chek2 = pers is Izdatelstvo;
            WriteLine(chek2);
            WriteLine("______AS_________");
            Persona chek3 = auth as Persona;
            WriteLine(chek3);
            Author chek4 = pers as Author;
            WriteLine(chek4);
            WriteLine("_____________________");

            Book boook = new Book(239,"ОНО","Ужасы",2003);
            Book boook2 = new Book(211, "Призраки", "Мистика", 1980);
            Book boook3= new Book(174, "Денискины рассказы", "Рассказ", 2013);
            Book boook4 = new Book(23, "Путешествие к центру земли", "Преключения", 2019);
            
            Book[] massBook = { boook, boook2,boook3, boook4 };

            PechatnoeIzdanie pechizd = new PechatnoeIzdanie("Рассказы","Мода","Математика");

            Uchebnik ucheb = new Uchebnik("Книжный","Физика",127);
            Uchebnik ucheb2 = new Uchebnik("Книжный", "Математика", 97);
            Uchebnik ucheb3 = new Uchebnik("Книжный", "Биология", 33);
            Uchebnik ucheb4 = new Uchebnik("Книжный", "Астрономия", 100);
            Uchebnik[] uchmass = {ucheb,ucheb2,ucheb3 };

            WriteLine("-------6 задание-----");
            WriteLine(izdat.ToString());
            WriteLine("_____________________");
            WriteLine(jurn.ToString());
            WriteLine("_____________________");
            WriteLine(boook.ToString());
            WriteLine("_____________________");
            WriteLine(pechizd.ToString());
            WriteLine("_____________________");
            WriteLine("ТЕЕЕЕЕССССТТТТ");
            Uchebnik[] mass2 = {ucheb,boook,jurn };
            WriteLine(((Interface2)ucheb).Sort(mass2));

            WriteLine("-------7 задание-----");
            
            Printer print = new Printer(3);

            
            List<object> array = new List<object>() {  ucheb, boook, print };
            foreach (Biblioteka ch in array)
            {
               print.IAmPrinting(ch);
            }
            WriteLine("-------6 ЛАБА-----");
            Biblioteka bibl = new Biblioteka();
            WriteLine("Количество Учебников в библиотеке:");
            WriteLine(ControllerBiblioteki.SummUch()+"\n");

            WriteLine("----3 Задание");
            bibl.set(boook);
            bibl.set(ucheb);
            bibl.set(jurn);
            bibl.Print();
            WriteLine("-----4 задание------");
            WriteLine(ControllerBiblioteki.BigYear(massBook, 2010));
            WriteLine("-------Работа с 1 заданием(Перечесление)-----");

            Printer print2 = new Printer(2);
            WriteLine(print2.GetInfo());
            WriteLine("-------Работа с 1 заданием(Структура)-----");
            Persona pers2 = new Persona("Приключения",22,"Артем");
            pers2.DoPerson("Голова","Руки","Тело","Глаза");
            WriteLine(pers2.InfoPerson());
            
           




        }
    }
}
