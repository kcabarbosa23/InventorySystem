namespace InventoryManagementSystem
{
    // A class representing a product in the inventory
    class Product
    {
        public int ProductId { get; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public double Price { get; set; }

        public Product(int productId, string name, int quantityInStock, double price)
        {
            ProductId = productId;
            Name = name;
            QuantityInStock = quantityInStock;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {Name}, Quantity: {QuantityInStock}, Price: {Price:C}";
        }
    }
}
