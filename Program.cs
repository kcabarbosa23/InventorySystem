using System;

namespace InventoryManagementSystem
{
    // Main Program Class which handles user interaction
    class Program
    {
        static InventoryManager inventoryManager = new InventoryManager();

        static void Main()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("\n===============================");
                Console.WriteLine("       Inventory System        ");
                Console.WriteLine("===============================\n");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Get Total Inventory Value");
                Console.WriteLine("6. Exit");
                Console.WriteLine("\n===============================");
                Console.WriteLine("\nEnter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;

                    case "2":
                        ViewProducts();
                        break;

                    case "3":
                        UpdateProduct();
                        break;

                    case "4":
                        DeleteProduct();
                        break;

                    case "5":
                        GetTotalInventoryValue();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Method that adds a new product to the inventory
        static void AddProduct()
        {
            while (true)
            {
                Console.WriteLine("\nEnter Product Name (or 'B' to go back): ");
                string name = Console.ReadLine();
                if (name.ToUpper() == "B") return;

                int qty;
                while (true)
                {
                    Console.WriteLine("\nEnter Quantity: ");

                    if (int.TryParse(Console.ReadLine(), out qty) && qty >= 0)
                        break;
                    Console.WriteLine("Invalid input. Quantity must be a non-negative integer.");
                }

                double price;
                while (true)
                {
                    Console.WriteLine("\nEnter Price: ");

                    if (double.TryParse(Console.ReadLine(), out price) && price >= 0)
                        break;
                    Console.WriteLine("Invalid input. Price must be a non-negative number.");
                }

                inventoryManager.AddProduct(new Product(inventoryManager.GenerateProductId(), name, qty, price));
                Console.WriteLine("\nProduct added successfully!");

                Console.Write("\nDo you want to add another product? (Y/N): ");
                string response = Console.ReadLine().ToUpper();
                if (response != "Y") return;
            }
        }

        // Method to view all the products in the inventory
        static void ViewProducts()
        {
            Console.WriteLine("\nCurrent Inventory: ");
            inventoryManager.ListProducts();

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Method that updates an existing product's quantity in the inventory
        static void UpdateProduct()
        {
            while (true)
            {
                Console.Write("\nEnter Product ID to Update (or 'B' to go back): ");
                string input = Console.ReadLine();

                if (input.ToUpper() == "B") return;

                if (int.TryParse(input, out int productId))
                {
                    Product product = inventoryManager.GetProductById(productId);
                    if (product == null)
                    {
                        Console.WriteLine("\nProduct not found! Please enter a valid Product ID.");
                        continue;
                    }

                    int newQuantity;
                    while (true)
                    {
                        Console.Write("\nEnter New Quantity: ");
                        if (int.TryParse(Console.ReadLine(), out newQuantity) && newQuantity >= 0)
                            break;
                        Console.WriteLine("\nInvalid input. Quantity must be a non-negative integer.");
                    }

                    Console.Write("\nAre you sure you want to update this product? (Y/N): ");
                    string confirm = Console.ReadLine().ToUpper();
                    if (confirm != "Y") return;

                    inventoryManager.UpdateProduct(productId, newQuantity);

                    Console.WriteLine("\nProduct updated successfully!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Product ID! Please enter a valid number.");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Method that deletes a product from the inventory
        static void DeleteProduct()
        {
            while (true)
            {
                Console.Write("\nEnter Product ID to Delete (or 'B' to go back): ");
                string input = Console.ReadLine();

                if (input.ToUpper() == "B") return;

                if (int.TryParse(input, out int productId))
                {
                    Product product = inventoryManager.GetProductById(productId);
                    if (product == null)
                    {
                        Console.WriteLine("\nProduct not found! Please enter a valid Product ID.");
                        continue;
                    }

                    Console.Write("\nAre you sure you want to delete this product? (Y/N): ");
                    string confirm = Console.ReadLine().ToUpper();
                    if (confirm != "Y") return;

                    inventoryManager.RemoveProduct(productId);
                    Console.WriteLine("Product deleted successfully!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Product ID! Please enter a valid number.");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Method that gets the total value of all the products in the inventory
        static void GetTotalInventoryValue()
        {
            double totalValue = inventoryManager.GetTotalValue();
            Console.WriteLine($"\nTotal Inventory Value: {totalValue:C}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
