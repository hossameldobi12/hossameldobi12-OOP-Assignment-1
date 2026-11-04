using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ConvertToOOP
{
    public class Customer
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? City { get; set; }
        public bool VIP { get; private set; }
        public static List<Customer> Customers = new List<Customer>();
        public Customer()
        {

        }

        public static void AddCustomer(Customer customer)
        {
            if (GetCustomerById(customer.Id) != null && customer.Id > 0)
            {
                Console.WriteLine($"Customer with Id {customer.Id} already exists.");
                return;
            }
            Customers.Add(customer);
        }

        public static void DisplayCustomers()
        {
            Console.WriteLine("\n########## ALL CUSTOMERS ###########");
            foreach (var customer in Customers)
            {
                Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}, City: {customer.City}, VIP: {customer.VIP}");
            }
            Console.WriteLine();
        }
        public static void CustomerSeeding()
        {
            Customer customer1 = new Customer()
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                City = "New York",
                VIP = true
            };
            Customer customer2 = new Customer()
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                City = "Chicago",
                VIP = false
            };
            Customer customer3 = new Customer()
            {
                Id = 3,
                Name = "Alice Johnson",
                Email = "alice.johnson@example.com",
                City = "Los Angeles",
                VIP = true
            };



            AddCustomer(customer1);
            AddCustomer(customer2);
            AddCustomer(customer3);


        }

        public static Customer? GetCustomerById(int customerId)
        {
            var customer = Customers?.Find(c => c.Id == customerId);

            return customer;
        }

    }


}
