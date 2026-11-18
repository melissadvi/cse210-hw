using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Charles Miller", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "NB100", 3.50, 4));
        order1.AddProduct(new Product("Pen Set", "PN205", 8.00, 2));

        Address address2 = new Address("Street 45", "Sao Paulo", "SP", "Brazil");
        Customer customer2 = new Customer ("Monica Geller", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Backpack", "BP310", 25.00, 1));
        order2.AddProduct(new Product("Water Bottle", "WB420", 12.50, 2));
        order2.AddProduct(new Product("Desk Lamp", "DL555", 18.75, 1));

        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();
    }
}