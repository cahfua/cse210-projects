using System;
using System.Globalization;

namespace OnlineOrdering
{
    internal class Program
    {
        private static void Main()
        {
            var addr1 = new Address("123 Elm St", "Boise", "ID", "USA");
            var cust1 = new Customer("Avery Carter", addr1);

            var order1 = new Order(cust1);
            order1.AddProduct(new Product("Wireless Mouse", "WM-100", 19.99m, 2));
            order1.AddProduct(new Product("Mechanical Keyboard", "MK-200", 59.50m, 1));

            var addr2 = new Address("77 King St W", "Toronto", "ON", "Canada");
            var cust2 = new Customer("Jordan Singh", addr2);

            var order2 = new Order(cust2);
            order2.AddProduct(new Product("USB-C Dock", "UC-310", 89.00m, 1));
            order2.AddProduct(new Product("HDMI Cable 2m", "HC-020", 8.25m, 3));
            order2.AddProduct(new Product("Laptop Stand", "LS-440", 28.00m, 1));

            PrintOrder(order1, "Order #1");
            Console.WriteLine();
            PrintOrder(order2, "Order #2");
        }

        private static void PrintOrder(Order order, string title)
        {
            Console.WriteLine(new string('=', title.Length));
            Console.WriteLine(title);
            Console.WriteLine(new string('=', title.Length));

            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"TOTAL: {order.GetTotalCost().ToString("C", CultureInfo.GetCultureInfo("en-US"))}");
        }
    }
}