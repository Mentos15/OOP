using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
     class Biblioteka :Abstrct2
    {


        public List<Uchebnik> uch = new List<Uchebnik>();

        public Uchebnik get(int uchebn)
        {
            return uch[uchebn];
        }
        public void set(Uchebnik uchebn)
        {
            uch.Add(uchebn);
        }


        public Biblioteka()
        {

        }

        public void Del(Uchebnik uchebn)
        {
            if (uch.Contains(uchebn))
            {
                uch.Remove(uchebn);
            }
            else
                throw new Iskl2($"Нельзя удалить, ибо лист пустой");
        }
        public void Print()
        {
            foreach (Uchebnik uchebn in uch)
            {
                Console.WriteLine(uchebn.ToString());
                Console.WriteLine("_____________________");
            }
        }

        public override string Sort(object[] objj)
        {
            Biblioteka[] obj = (Biblioteka[])objj;
            Biblioteka vrem;
            string mass2 = "";
            for (int i = 0; i < obj.Length; i++)
            {
                for (int j = 0; j < obj.Length; j++)
                {
                    if (obj[i].ColStr > obj[j].ColStr)
                    {
                        vrem = obj[i];
                        obj[i] = obj[j];
                        obj[j] = vrem;
                    }
                }

            }
            for (int i = 0; i < obj.Length; i++)
            {

                Console.WriteLine(obj[i]);
                Console.WriteLine("_____________________");
            }
            return mass2;
        }


    }
}
