using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    partial class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1,CategoryName="Bilgisayar"},
                new Category{CategoryId=2,CategoryName="Telefon"}
            };

            List<Product> products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Acer Laptop",QuantityPerUnit="32 GB RAM",UnitPrice=10000,UnitsInStock=5},
                new Product{ProductId=2,CategoryId=1,ProductName="Asus Laptop",QuantityPerUnit="16 GB RAM",UnitPrice=8000,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=1,ProductName="Hp Laptop",QuantityPerUnit="8 GB RAM",UnitPrice=6000,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="SAMSUNG Telefon",QuantityPerUnit="4 GB RAM",UnitPrice=5000,UnitsInStock=15},
                new Product{ProductId=5,CategoryId=2,ProductName="Apple Telefon",QuantityPerUnit="4 GB RAM",UnitPrice=8000,UnitsInStock=0}
            };
            //Test(products);
            //AnyTest(products);
            //FindTest(products);
            //FindAllTest(products);
            //AscDescTest(products);
            //SelectTest(products);

            var results = from p in products
                          join c in categories
       on p.CategoryId equals c.CategoryId
       where p.UnitPrice>5000
                          select new ProductDto
                          {
                              ProductId = p.ProductId,
                              ProductName = p.ProductName,
                              CategoryName = c.CategoryName,
                              UnitPrice = p.UnitPrice
                          };

            foreach (var result in results)
            {
                Console.WriteLine(result.ProductName+" "+result.CategoryName);
            }

            Console.ReadKey();
        }

        private static void SelectTest(List<Product> products)
        {
            var results = from p in products
                          where p.UnitPrice > 6000
                          orderby p.UnitPrice descending
                          select p;

            foreach (var result in results)
            {
                Console.WriteLine(result.ProductName);
            }
        }

        private static void AscDescTest(List<Product> products)
        {
            var results = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice);
            foreach (var result in results)
            {
                Console.WriteLine(result.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            var results = products.FindAll(p => p.ProductName.Contains("top"));
            foreach (var result in results)
            {
                Console.WriteLine(result.ProductName);
            }
        }

        private static void FindTest(List<Product> products)
        {
            var result = products.Find(p => p.ProductId == 1);
            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Laptop");
            Console.WriteLine(result);
        }

        private static void Test(List<Product> products)
        {
            var result = GetAll(products);

            foreach (var p in result)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        static List<Product> GetAll(List<Product> products)
        {
            return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();
        }
    }
}
