using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSInterface
{
    internal class Program
    {
        class Parent { }
        class Child : Parent, IComparable<Child>, IDisposable
        {
            public int CompareTo(Child other)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        class TestClass : IBasic
        {
            public int TestProperty { 
                get { return -1; }
                set { int n = value; }
            }

            public int TestInstanceMethod()
            {
                // do something...
                return 1;
            }
        }

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

        class Dummy : IDisposable
        {
            public void Dispose() {
                Console.WriteLine("Disposable 메서드 호출됨");
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

            using (Dummy dummy = new Dummy())
            {
                Console.WriteLine("using 블록 안에 들어왔습니다.");
            }
            Console.WriteLine("using블록을 벗어났습니다.");

            // ew......
            // 다향성!
            TestClass tc = new TestClass();
            IBasic ib = tc;
            IBasic ib2 = new TestClass();
            TestClass tc2 = (TestClass)ib2;
            TestClass tc3 = (TestClass)ib;

            Child child = new Child();
            Parent parent = child;
            IDisposable childAsDisposable = new Child();
            IComparable<Child> childAsCompareable = new Child();
        }
    }
}
