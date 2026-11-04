using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ConvertToOOP
{
    public class Product
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public static List<Product> Products = new List<Product>();

        public Product()
        {

        }

        public Product(int id, string name, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public static void AddProduct(Product product)
        {
            if (GetProductById(product.Id) != null && product.Id > 0)
            {
                Console.WriteLine($"Product with Id {product.Id} already exists.");
                return;
            }
            Products.Add(product);
        }
        public static void DisplayProducts()
        {
            Console.WriteLine("\n########## ALL PRODUCTS ###########");

            foreach (var product in Products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
            }
            Console.WriteLine();
        }
        public static void ProductsSeeding()
        {
            Product product1 = new Product(101, "USB Cable", 50.0m, 100);
            Product product2 = new Product(102, "Wireless Mouse", 250.0m, 40);
            Product product3 = new Product(103, "Mechanical Keyboard", 1200.0m, 15);
            Product product4 = new Product(104, "Laptop Stand", 400.0m, 25);


            AddProduct(product1);
            AddProduct(product2);
            AddProduct(product3);
            AddProduct(product4);
            
        }

        public static Product? GetProductById(int productId)
        {
            var product = Products?.Find(p => p.Id == productId);
            return product;
        }


    }
}
