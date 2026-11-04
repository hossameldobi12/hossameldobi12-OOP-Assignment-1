using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ConvertToOOP
{
    public class Helper
    {
        public static void CreateOrder()
        {
            if (!TryReadInt("Please enter order ID:", out int orderId))
                return;
            if (Order.GetOrderById(orderId) != null)
            {
                Console.WriteLine("Order with this id arleedy exist");
                return;
            }
            if (!TryReadInt("Please enter customer ID:", out int CustomerId))
                return;
            if (Customer.GetCustomerById(CustomerId) == null)
            {
                Console.WriteLine("there is no customer with this id ");
                return;
            }
            Order order = new Order(orderId, CustomerId);
            Order.AddOrder(order);
        }
        public static void AddOrderLineToOrder()
        {
            if (!TryReadInt("Please enter order ID:", out int orderId))
                return;
            var order = Order.GetOrderById(orderId);
            if (order == null)
            {
                Console.WriteLine("the is no order with this id ");
                return;
            }
            if(order.Ispaid)
            {
                Console.WriteLine("This order is already paid. Cannot add more items.");
                return;
            }

            if (!TryReadInt("Please enter product ID:", out int productId))
                return;
            var product = Product.GetProductById(productId);
            if (product == null)
            {
                Console.WriteLine("the is no product with this id ");
                return;
            }
            if (!TryReadInt("Please enter quantity:", out int quantity))
                return;
            if(quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                return;
            }
            if (quantity > product.Stock )
            {
                Console.WriteLine("The Quantity Not avalibale in stock");
                return;
            }

            OrderLine orderLine = new OrderLine(product, quantity);
            order.AddOrderLine(orderLine);

        }
        public static void MarkOrderAsPaied()
        {
            if (!TryReadInt("Please enter order ID:", out int orderId))
                return;
            var order = Order.GetOrderById(orderId);
            if (order == null)
            {
                Console.WriteLine("the is no order with this id ");
                return;
            }
            order.MarkPaied();
        }
        public static void ShowPaiedSalesTotal()
        {
            decimal total = 0;
            if (Order.orders is not null)
            {
                foreach (var order in Order.orders)
                {
                    if (order.Ispaid)
                        total += order.GetTotalAmount();
                }
                Console.WriteLine($"The Total Amount paied : {total} ");
            }
        }
        public static void DisplayAllProduct()
        {
            Product.DisplayProducts();
        }
        public static void DisplayAllCustomers()
        {
            Customer.DisplayCustomers();
        }
        public static void DisplayAllOrders()
        {
            Order.DisplayAllOrders();
        }
        public static void DisplayOrderById()
        {
            if (!TryReadInt("Please enter order ID:", out int orderId))
                return;
            var order = Order.GetOrderById(orderId);
            if (order == null)
            {
                Console.WriteLine("the is no order with this id ");
                return;
            }
            Order.DisplayOrder(order);
        }

        private static bool TryReadInt(string prompt, out int value)
        {
            Console.WriteLine(prompt);

            if (int.TryParse(Console.ReadLine(), out value))
                return true;

            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return false;
        }

    }


}
