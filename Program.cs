using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ENDRYU_TROELSEN_PRACTIC_1
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Alex", 100);
            var Products = Product.GetList();
            while (true)
            {
                Console.WriteLine(user.ToString());
                Product.ListToConsole(Products);
                user.BuyItem(Products);
                Console.WriteLine("Do you want to purchase?(Y)");
                Console.ReadLine();
            }
        }
    }
}
