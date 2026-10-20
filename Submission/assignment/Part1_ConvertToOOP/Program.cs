
using Part1_ConvertToOOP;

bool flag = true;

Customer.CustomerSeeding();
Product.ProductsSeeding();
Order.OrderSeeding();

Console.WriteLine("                            #########  Order System ############                ");
Console.WriteLine();
Customer.DisplayCustomers();
Product.DisplayProducts();
Order.DisplayAllOrders();



while (flag)
{
    Console.WriteLine("-------------MENU------------");
    Console.WriteLine("1- Print All Customers");
    Console.WriteLine("2- Print All Products");
    Console.WriteLine("3- Print All Orders");
    Console.WriteLine("4- Print Order Details By ID");
    Console.WriteLine("5- Create Order");
    Console.WriteLine("6- Add Line To Order");
    Console.WriteLine("7- Mark Order Paied");
    Console.WriteLine("8- Show Paied Sales Total");
    Console.WriteLine("0- Exit");

    Console.Write("Please enter your choice: ");
    var input = Console.ReadLine();
    switch (input)
    {

        case "1":
            Helper.DisplayAllCustomers();
            break;

        case "2":
            Helper.DisplayAllProduct();
            break;

        case "3":
            Helper.DisplayAllOrders();
            break;

        case "4":
            Helper.DisplayOrderById();
            break;
        case "5":
            Helper.CreateOrder();
            break;
        case "6":
            Helper.AddOrderLineToOrder();
            break;
        case "7":
            Helper.MarkOrderAsPaied();
            break;
        case "8":
            Helper.ShowPaiedSalesTotal();
            break;
        case "0":
            flag = false;
            break;
        default:
            Console.WriteLine("\nInvalid input. Please try again.\n");
            break;

    }


}