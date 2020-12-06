using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENDRYU_TROELSEN_PRACTIC_1
{
    public class User
    {
        private string _name;
        private double _balance;
        private string Name { get => _name; set => _name = value != null ? value : throw new Exception("Wrong username"); }
        private double Balance { get => _balance; set => _balance = value >= 0 ? value : throw new BalanceLowerThanZeroException("You havent so much money"); }
        public User(string Name, double Balance)
        {
            this.Name = Name;
            this.Balance = Balance;
        }
        public override string ToString()
        {
            return $"*********USER INFO*********\n*Name: {Name}; Balance:{Balance};*\n***************************";
        }
        public void BuyItem(Product[] Products)
        {
            Console.WriteLine("What product you want to choose?(Write number of product)");
            var products = Products;
            int index = int.Parse(Console.ReadLine());
            double PreviousBalance = Balance;
            try
            {
                Balance -= products[index - 1].GetPrice();
                if (products[index - 1].PurchaseOperation(true))
                {
                    Console.WriteLine($"{Name} have bought {products[index - 1].GetName()}, thank for your purchase!");
                    Console.WriteLine($"Your previous balance {PreviousBalance}");
                    Console.WriteLine($"Your final balance {Balance}");
                }
                else 
                    Balance += products[index - 1].GetPrice();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Operation Denied. Undetefied product number");
            }
            catch (BalanceLowerThanZeroException e)
            {
                Console.WriteLine(e.Message);
                products[index - 1].TryPurchaseOperation(true);
            }
        }
    }
}
