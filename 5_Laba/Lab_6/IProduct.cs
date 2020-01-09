using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    interface IProduct
    {
        float price { get; set; }
        int numberOfProducts { get; set; }
        string sell();
    }
}
