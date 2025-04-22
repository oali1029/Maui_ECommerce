using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.eCommerce.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Library.eCommerce.ViewModels
{
    public class CartViewModel : ObservableObject
    {
        private ObservableCollection<CartItem> _cartItems;

        public ObservableCollection<CartItem> CartItems
        {
            get => _cartItems;
            set => SetProperty(ref _cartItems, value);
        }

        public decimal TotalPrice => CartItems.Sum(item => item.Product.Price * item.Quantity);
        public decimal SalesTax => TotalPrice * 0.07m; // 7% sales tax
        public decimal TotalWithTax => TotalPrice + SalesTax;

        public CartViewModel()
        {
            CartItems = new ObservableCollection<CartItem>();
        }

        public void AddToCart(Product product)
        {
            var cartItem = CartItems.FirstOrDefault(item => item.Product == product);
            if (cartItem != null)
            {
                if (cartItem.Quantity < product.QuantityInStock)
                    cartItem.Quantity++;
            }
            else
            {
                CartItems.Add(new CartItem { Product = product, Quantity = 1 });
            }
        }

        public void RemoveFromCart(CartItem cartItem)
        {
            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
            else
            {
                CartItems.Remove(cartItem);
            }
        }
    }
}

