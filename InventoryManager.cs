using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    // A class to manage the inventory
    class InventoryManager
    {
        private int currentProductId = 1;

        private List<Product> inventory = new List<Product>();

        // Generates a unique non-negative product ID
        public int GenerateProductId()
        {
            return currentProductId++;
        }

        // Adds a new product to the inventory list
        public void AddProduct(Product product)
        {
            inventory.Add(product);
        }

        // Removes a product from the inventory list based on ID
        public void RemoveProduct(int productId)
        {
            int index = inventory.FindIndex(p => p.ProductId == productId);

            if (index != -1)
            {
                inventory.RemoveAt(index);
            }
        }

        // Updates an existing product's quantity based on ID 
        public void UpdateProduct(int productId, int newQuantity)
        {
            int index = inventory.FindIndex(p => p.ProductId == productId);

            if (index != -1)
            {
                inventory[index].QuantityInStock = newQuantity;
            }
        }

        // Displays all products in the inventory
        public void ListProducts()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("No products in inventory.");
                return;
            }
            else
            {
                Console.WriteLine("\n{0,-5} {1,-20} {2,-10} {3,-10}", "ID", "Name", "Qty", "Price");
                Console.WriteLine(new string('-', 50));

                foreach (var product in inventory)
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10:C}",
                        product.ProductId, product.Name, product.QuantityInStock, product.Price);
                }
            }
        }

        // Gets the total value of all the products in the inventory
        public double GetTotalValue()
        {
            double totalValue = 0;

            foreach (var product in inventory)
            {
                totalValue += product.QuantityInStock * product.Price;
            }

            return totalValue;
        }

        public Product GetProductById(int productId)
        {
            return inventory.Find(p => p.ProductId == productId);
        }
    }
}
