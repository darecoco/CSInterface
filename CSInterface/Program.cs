using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSInterface
{
    internal class Program
    {
        class Product : IComparable<Product>
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public int CompareTo(Product other)
            {
                return this.Price.CompareTo(other.Price);
                // return this.Name.CompareTo(other.Name);
            }

            public string ToString()
            {
                return Name + "은(는) " + Price + "원.";
            }
        }

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product() {Name="감자", Price=1500},
                new Product() {Name="고구마", Price=5000},
                new Product() {Name="양파", Price=1400},
                new Product() {Name="배추", Price=2300},
                new Product() {Name="양상추", Price=1300},
            };

            products.Sort();

            foreach (Product p in products)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
