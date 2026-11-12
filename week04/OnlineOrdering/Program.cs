using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: USA Customer
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        
        order1.AddProduct(new Product("Wireless Mouse", "WM-01", 25.99, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "KB-02", 79.99, 1));

        // Order 2: International Customer
        Address address2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);
        Order order2 = new Order(customer2);
        
        order2.AddProduct(new Product("USB-C Hub", "UC-03", 19.99, 3));
        order2.AddProduct(new Product("Monitor Stand", "MS-04", 45.50, 1));

        // Display results for both orders
        Order[] orders = { order1, order2 };
        for (int i = 0; i < orders.Length; i++)
        {
            Console.WriteLine($"=== ORDER {i + 1} ===");
            Console.WriteLine(orders[i].GetPackingLabel());
            Console.WriteLine(orders[i].GetShippingLabel());
            Console.WriteLine($"Total Cost: ${orders[i].CalculateTotalCost():F2}\n");
        }
    }
}