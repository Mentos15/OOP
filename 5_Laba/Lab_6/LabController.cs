using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    static class LabController
    {
        public static Labaratory YearsOfService (Labaratory lab, int desiredyear)
        {
            Labaratory temp = new Labaratory();
            foreach (Tech tech in lab._tech)
                if (tech.year > desiredyear)
                    temp.set(tech);
            return temp;
        }

        public static (int nComputer, int nTablets, int nPrinters, int nScanners) Number(Labaratory lab)
        {
            int nC = 0, nT = 0, nP = 0, nS = 0;
            foreach (Tech tech in lab._tech)
            {
                if (tech.GetType() == typeof(Computer))
                    nC++;
                else if (tech.GetType() == typeof(Tablet))
                    nT++;
                else if (tech.GetType() == typeof(Printer))
                    nP++;
                else if (tech.GetType() == typeof(Scaner))
                    nS++;
            }
            return (nC, nT, nP, nS);
        }

        public static Labaratory PriceL(Labaratory lab)
        {
            Labaratory temp = new Labaratory();
            temp._tech = lab._tech.ToList();
            temp._tech.Sort();
            return temp;
        }
    }
}
