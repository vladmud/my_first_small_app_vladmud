using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENDRYU_TROELSEN_PRACTIC_1
{
    public abstract class Product
    {
        private string _name;
        private DateTime _manufactureDate = DateTime.Now;
        private DateTime _expirationDate = DateTime.Now.AddYears(1);
        private double _price;
        private int _amountOfProduct;
        protected virtual string Name 
        { get => _name; set => _name = value != null ? value : "Exception_Product_Name"; }
        protected virtual DateTime ManufactureDate 
        { get => _manufactureDate; set => _manufactureDate = value; }
        protected virtual DateTime ExpirationDate
        { get => _expirationDate; set => _expirationDate = value; }
        protected virtual double Price
        { get => _price; set => _price = value > 0 ? value : 0.01; }
        protected int NumberOfProduct { get; }
        protected int AmountOfProduct 
        { get => _amountOfProduct; set => _amountOfProduct = value >= 0 ? value : throw new AmountLessThanZero(); }
        public Product(string Name, DateTime ManufactureDate, DateTime ExpirationDate, double Price, int NumberOfProduct, int AmountOfProduct)
        {
            this.Name = Name;
            this.ManufactureDate = ManufactureDate;
            this.ExpirationDate = ExpirationDate;
            this.Price = Price;
            this.NumberOfProduct = NumberOfProduct;
            this.AmountOfProduct = AmountOfProduct;
        }
        public override string ToString()
        {
            return $"Product: {Name};  PRICE: {Price} gryven; NUMBER OF PRODUCT: {NumberOfProduct} \n" +
                $"Amount of Product {AmountOfProduct}\n" +
                $"\t Date of manufacture: {ManufactureDate.ToLongDateString()} \n" +
                $"\t Date of Expiration: {ExpirationDate.ToLongDateString()} \n";
        }
        public static Product[] GetList()
        {
            int AmountOfProducts = 10;
            Product[] Products = new Product[AmountOfProducts];
            for (int i = 0; i < Products.Length; i++)
            {
                Products[i] = new Apple(i + 1);
            }
            return Products;
        }
        public static void ListToConsole(Product[] Products)
        {
            foreach (var Product in Products)
            {
                Console.WriteLine(Product.ToString());
            }
        }
        public string GetName() => Name;
        public double GetPrice() => Price;
        public bool PurchaseOperation(bool IsPurchaseSucced)
        {
            var PreviousAmountOfProduct = AmountOfProduct;
            try
            {
                if (IsPurchaseSucced)
                {
                    AmountOfProduct--;
                    return true;
                }
                else
                    throw new BalanceLowerThanZeroException();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public bool TryPurchaseOperation(bool IsPurchaseSucced)
        {
            var PreviousAmountOfProduct = AmountOfProduct;
            PurchaseOperation(IsPurchaseSucced);
            if (PreviousAmountOfProduct > 0)
            {
                AmountOfProduct = PreviousAmountOfProduct;
                return false;
            }
            else return true;
        }
    }
    public class Apple : Product
    {
        public Apple(string Name, DateTime ManufactureDate, DateTime ExpirationDate, double Price, int NumberOfProduct, int AmountOfProduct, double AmountOfFructoza)
            : base(Name, ManufactureDate, ExpirationDate, Price, AmountOfProduct, NumberOfProduct)
        {
            this.AmountOfFructoza = AmountOfFructoza;
        }
        public Apple(int NumberOfProduct) : this("Apple", new DateTime(2020, 7, 17), new DateTime(2021, 8, 7), 50, 1,NumberOfProduct, 67.5){ }
        protected double AmountOfFructoza { get; set; }
        public override string ToString()
        {
            return base.ToString()
                +$"\t Amount of fructoza: {AmountOfFructoza}%";
        }
    }
}
