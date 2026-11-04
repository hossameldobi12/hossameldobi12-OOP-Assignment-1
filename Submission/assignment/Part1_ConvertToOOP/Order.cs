using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ConvertToOOP
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool Ispaid { get;private set; } = false;
        public List<OrderLine>? OrderLines { get;  }

        public static List<Order>? orders { get; set; } = new List<Order>();
        public Order(int id, int customerId)
        {
            Id = id;
            CustomerId = customerId;
            OrderLines = new List<OrderLine>();



        }
        public static void DisplayAllOrders()
        {
            Console.WriteLine("\n########## ALL ORDERS ###########");
            if (orders is null)
            {
                Console.WriteLine("there is no orders");
                return;
            }
            foreach (var order in orders)
            {
                DisplayOrder(order);
            }
            Console.WriteLine();
        }
        public static void DisplayOrder(Order order)
        {


            Console.WriteLine($"Order Id: {order.Id}, Customer Id: {order.CustomerId}, Is Paid: {order.Ispaid},Total = {order.GetTotalAmount()}");
            if (order.OrderLines != null)
            {
                foreach (var orderLine in order.OrderLines)
                {
                    Console.WriteLine($"    Product: {orderLine.Product.Name}, Quantity: {orderLine.Quantity}, Total Price: {orderLine.GetTotalPrice()}");

                }
            }

            Console.WriteLine();
        }
        public static void AddOrder(Order order)
        {

            orders?.Add(order);
        }
        public void AddOrderLine(OrderLine orderLine)
        {

           OrderLines?.Add(orderLine);

        }
        public decimal GetTotalAmount()
        {
            decimal totalAmount = 0;
            if (OrderLines != null)
            {
                foreach (var orderLine in OrderLines)
                {
                    totalAmount += orderLine.GetTotalPrice();
                }
            }
            return totalAmount;
        }
        public void MarkPaied()
        {
            Ispaid = true;
        }
        public static void OrderSeeding()
        {
            Order order1 = new Order(1, 1);
            Order order2 = new Order(2, 2);
            Order order3 = new Order(3, 3);

            order1.AddOrderLine(new OrderLine(new Product(101, "USB Cable", 50.0m, 100), 5));
            order2.AddOrderLine(new OrderLine(new Product(102, "Wireless Mouse", 250.0m, 40), 5));
            order3.AddOrderLine(new OrderLine(new Product(101, "USB Cable", 50.0m, 100), 5));

            AddOrder(order1);
            AddOrder(order2);
            AddOrder(order3);
        }

        public static Order? GetOrderById(int orderId)
        {
            var order = orders?.Find(o => o.Id == orderId);

            return order;
        }





    }
}
