using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    partial class Author
    {

        public string Name { get; set; }
        public string Janr { get; set; }
        public int Age { get; set; }
        public Author()
        {

        }
        public Author(string name, int age, string janr)
        {
            Name = name;
            Age = age;
            Janr = janr;
        }

        virtual public string GetInfo()
        {
            return ($"Имя автора: {Name} \n Возраст: {Age} \n Жанр: {Janr}");
        }

    }
}
