// This program follows the principle of encapsulation

using System;

class Program
{
    static void Main(string[] args)
    {
        // Create address for customer 1 (in the USA).
        Address address1 = new Address("123 Maple St", "Los Angeles", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        // Create address for customer 2 (outside the USA).
        Address address2 = new Address("Oluyole Estate", "Ibadan", "Oyo", "Nigeria");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create two orders for the customers.
        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);

        // Add products to order 1.
        order1.AddProduct(new Product("Laptop", "L123", 800.00, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25.00, 2));

        // Add products to order 2.
        order2.AddProduct(new Product("Smartphone", "S789", 600.00, 1));
        order2.AddProduct(new Product("Charger", "C101", 30.00, 1));

        // Display details for order 1.
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}\n");

        // Display details for order 2.
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}");
    }
}