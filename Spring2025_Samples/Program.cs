using Library.eCommerce.Models;
using Library.eCommerce.ViewModels;
using System;

namespace Spring2025_Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create some example data from the Library.eCommerce
            var inventoryViewModel = new InventoryViewModel();
            var cartViewModel = new CartViewModel();

            // Display all inventory items
            Console.WriteLine("Inventory:");
            foreach (var product in inventoryViewModel.Inventory)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price:C}, Quantity In Stock: {product.QuantityInStock}");
            }

            // Add a product to the cart
            var productToAdd = inventoryViewModel.Inventory[0];  // Assuming adding first product
            cartViewModel.AddToCart(productToAdd);
            Console.WriteLine($"Added {productToAdd.Name} to cart.");

            // Display cart total
            Console.WriteLine($"Total: {cartViewModel.TotalWithTax:C}");
        }
    }
}
