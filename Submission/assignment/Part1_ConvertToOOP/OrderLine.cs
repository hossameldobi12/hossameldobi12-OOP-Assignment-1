using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ConvertToOOP
{
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public decimal GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}
