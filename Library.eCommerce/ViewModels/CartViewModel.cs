using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Library.eCommerce.ViewModels
{
    public class CartViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CartItem> _cartItems;

        public ObservableCollection<CartItem> CartItems
        {
            get => _cartItems;
            set
            {
                if (_cartItems != value)
                {
                    _cartItems = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice));
                    OnPropertyChanged(nameof(SalesTax));
                    OnPropertyChanged(nameof(TotalWithTax));
                }
            }
        }

        public decimal TotalPrice => CartItems.Sum(item => item.Product.Price * item.Quantity);
        public decimal SalesTax => TotalPrice * 0.07m; // 7% sales tax
        public decimal TotalWithTax => TotalPrice + SalesTax;

        // Constructor to initialize the cart
        public CartViewModel()
        {
            CartItems = new ObservableCollection<CartItem>();
        }

        // Add a product to the cart or increment quantity if already in cart
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

            OnPropertyChanged(nameof(TotalPrice));
            OnPropertyChanged(nameof(SalesTax));
            OnPropertyChanged(nameof(TotalWithTax));
        }

        // Remove an item from the cart or decrement quantity
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

            OnPropertyChanged(nameof(TotalPrice));
            OnPropertyChanged(nameof(SalesTax));
            OnPropertyChanged(nameof(TotalWithTax));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
