using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9
{
   

    class Game
    {
        public delegate void D1();
        public delegate void D2();

        public event D1 Attack;
        public event D2 Heal;
        public void run() => Attack();
        public void save() => Heal();
    }

    class Realiz
    {
        public void Fire() => Console.WriteLine("Вас атаковали!!");
    }
    class HP
    {
        public void heal() => Console.WriteLine("Вы повысили уровень вашего здоровья на 20");
    }
    static class Methods
    {
        public static string DelZnak(string str)
        {
            int fix = 0;
            foreach (char symb in str)
            {
                fix++;
                if (symb == ',' || symb == '.' || symb == '!' || symb == '?' || symb == ':')
                {
                    str = str.Remove(fix - 1, 1);
                    fix--;
                }
               
            }
            return str;
        }
        public static string Sabaka(string str)
        {
            str = str.Replace('а', '@');
            return str;
        }
        public static string UPP(string str)
        {
            str = str.ToUpper();
            return str;
        }
        public static string low(string str)
        {
            str = str.ToLower();
            return str;
        }
        public static void ACT(string str)
        {
            str = str + "Присоеденил текст";
            Console.WriteLine(str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game pers1 = new Game();
            Realiz r = new Realiz();
            pers1.Attack += r.Fire;
            pers1.run();

            HP hp = new HP();
            pers1.Heal += hp.heal;
            Console.WriteLine("Сколько будет 13+2? За правильный ответ вы получите 20hp ");
            string x = Console.ReadLine();

            if(x == "15")
            {
                pers1.save();
            }
            else
            {
                Console.WriteLine("Увы, ответ не правильный, вы погибли");
            }
            string stroka = "Привет. цйуйцкуй, цйк! авыацмва";
            Func<string,string> fu;
            fu = Methods.DelZnak;
            stroka = fu(stroka);
            Console.WriteLine(fu(stroka));
            fu += Methods.Sabaka;
            stroka = fu(stroka);
            Console.WriteLine(fu(stroka));
            fu += Methods.UPP;
            stroka = fu(stroka);
            Console.WriteLine(fu(stroka));
            fu += Methods.low;
            stroka = fu(stroka);
            Console.WriteLine(fu(stroka));
            Action<string> ac;
            ac = Methods.ACT;
            ac(stroka);

        }
       
    }
}
