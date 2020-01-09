using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text.Json;


namespace LP_Lab14
{
    
    
    public class Program
    {
        public class Team
        {
            public string Name { get; set; }
            public string Coach { get; set; }
        } 

        [Serializable]
        public class Book : Uchebnik
        {


            public string Name { get; set; }
            public string Janr { get; set; }
            public int Year { get; set; }

            public Book()
            {

            }
            
            public Book(int colstr, string name, string janr, int year)
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
        [Serializable]
        public class Uchebnik
        {
            public static int count = 0;


            public string Pereplet
            {
                get; set;
            }
            public string Predmet
            {
                get; set;
            }
            public int ColStr
            {
                get; set;
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
        }
        static void Main(string[] args)
        {
            Book book1 = new Book(124,"Math", "School", 2007);
            Uchebnik uch =  new Uchebnik("Книжный","Физика",93);
            Console.WriteLine("-----------БИНАРНАЯ------------");
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("C:\\Users\\Виталий\\ООП\\14_Laba\\points.dat",
            FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, book1);
            }
         
            using (FileStream fs = new FileStream("C:\\Users\\Виталий\\ООП\\14_Laba\\points.dat",
            FileMode.OpenOrCreate))
            {
                Book newPoint = (Book)formatter.Deserialize(fs);
                Console.WriteLine(newPoint.ToString());
            }
            Console.WriteLine("-------------------------------");

            Console.WriteLine("-------------SOAP------------------");
            SoapFormatter sf = new SoapFormatter();
            using (FileStream stream = new FileStream("C:\\Users\\Виталий\\ООП\\14_Laba\\SF.soap", FileMode.Create))
            {
                sf.Serialize(stream, uch);
            }
            using (FileStream stream = new FileStream("C:\\Users\\Виталий\\ООП\\14_Laba\\SF.soap", FileMode.Open))
            {
                Uchebnik ucheb = (Uchebnik)sf.Deserialize(stream);
                Console.WriteLine($"Soap:\n\tPereplet: {ucheb.Pereplet} \n \tPredmet: {ucheb.Predmet} \n\tColStr {ucheb.ColStr}" );
            }
            Console.WriteLine("-------------------------------");

            Console.WriteLine("-------------JSON------------------");
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Uchebnik));
            using (FileStream stream = new FileStream("C:\\Users\\Виталий\\ООП\\14_Laba\\qwe.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(stream, uch);
            }
            using (FileStream stream = new FileStream("C:\\Users\\Виталий\\ООП\\14_Laba\\qwe.json", FileMode.Open))
            {
                Uchebnik ucheb2 = (Uchebnik)jsonFormatter.ReadObject(stream);
                Console.WriteLine($"JSON:\n\tPereplet: {ucheb2.Pereplet} \n \tPredmet: {ucheb2.Predmet} \n\tColStr {ucheb2.ColStr}");
            }
            Console.WriteLine("-------------------------------");

            Console.WriteLine("-------------XML------------------");
            XmlSerializer xSer = new XmlSerializer(typeof(Book));
           
            using (FileStream fs = new FileStream("C:\\Users\\Виталий\\ООП\\14_Laba\\points.xml", FileMode.OpenOrCreate))
            {
                xSer.Serialize(fs, book1);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("C:\\Users\\Виталий\\ООП\\14_Laba\\points.xml", FileMode.OpenOrCreate))
            {
                Book newP = xSer.Deserialize(fs) as Book;
                Console.WriteLine(newP.ToString());
                Console.WriteLine("Объект десериализован");
            }
            Console.WriteLine("-------------------------------");

            Console.WriteLine("------------2 ЗАДАНИЕ-------------------");
            Book book2 = new Book(172,"English","Ucheba",2001);
            Book book3 = new Book(51, "Russian", "Ucheba", 2001);
            Book book4 = new Book(113, "Belarusian", "Ucheba", 1993);
            Book[] books = {book2, book3,book4 };

            Uchebnik uch1 = new Uchebnik("Книжный","Algebra",53);
            Uchebnik uch2 = new Uchebnik("Книжный", "Phiziks", 114);
            Uchebnik uch3 = new Uchebnik("Книжный", "Geometry", 205);
            Uchebnik[] uchs = { uch1, uch2, uch3 };

            XmlSerializer xmls = new XmlSerializer(typeof(Book[]));
            using (FileStream stream = new FileStream("C:\\Users\\Виталий\\ООП\\14_Laba\\pointsTask2.xml", FileMode.Create))
            {
                xmls.Serialize(stream, books);
            }
            using (FileStream stream = new FileStream("C:\\Users\\Виталий\\ООП\\14_Laba\\pointsTask2.xml", FileMode.Open))
            {
                Console.WriteLine("Xml task2");
                Book[] books2 = (Book[])xmls.Deserialize(stream);
                foreach (Book x in books2)
                {
                    Console.WriteLine("\tName: " + x.Name);
                }
            }

            Console.WriteLine("----------- 3 ЗАДАНИЕ ------------- ");

            XmlDocument xd = new XmlDocument();
            xd.Load("C:\\Users\\Виталий\\ООП\\14_Laba\\pointsTask2.xml");
            XmlElement xr = xd.DocumentElement;
            Console.WriteLine("\nName - English: ");
            XmlNode childnode = xr.SelectSingleNode("Book[Name='English']");
            foreach(XmlNode n in childnode)
            {
                if (n != null)
                {
                    Console.Write(n.OuterXml);
                }
            }
            Console.WriteLine();
            Console.WriteLine("\nyear = 2001: ");
            XmlNodeList childnodes = xr.SelectNodes("Book[Year='2001']");
            foreach (XmlNode n in childnodes)
            {
                Console.WriteLine(n.OuterXml);
            }
            Console.WriteLine("----------- 4 ЗАДАНИЕ ------------- ");

            Console.WriteLine("\nLINQ to XML");
            XDocument xdoc = new XDocument();
           
            XElement team = new XElement("team");
            
            XAttribute team_name_attribut = new XAttribute("name", "Arsenal");
            XElement team_league_elem = new XElement("league", "APL");
            XElement team_coach_elem = new XElement("leader", "Ozil");
           
            team.Add(team_name_attribut);
            team.Add(team_league_elem);
            team.Add(team_coach_elem);

          
            XElement team2 = new XElement("team");

            XAttribute team2_name_attribut = new XAttribute("name", "Barselona");
            XElement team2_league_elem = new XElement("league", "APL");
            XElement team2_coach_elem = new XElement("leader", "Messi");
          
            team2.Add(team2_name_attribut);
            team2.Add(team2_league_elem);
            team2.Add(team2_coach_elem);

           
            XElement teams = new XElement("teams");
            
            teams.Add(team);
            teams.Add(team2);
           
            xdoc.Add(teams);
           
            xdoc.Save("C:\\Users\\Виталий\\ООП\\14_Laba\\teams.xml");

            var items = from xe in xdoc.Elements("teams").Elements("team")
                        where xe.Element("league").Value == "APL"
                        select new Team
                        {
                            Name = xe.Attribute("name").Value,
                            Coach = xe.Element("leader").Value
                        };
            foreach (var item in items)
            {
                Console.WriteLine("\t{0} - {1}", item.Name, item.Coach);
            }
        }
    }
}
