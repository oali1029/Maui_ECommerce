using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Library.eCommerce.ViewModels
{
    public class InventoryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _inventory;
        public ObservableCollection<Product> Inventory
        {
            get => _inventory;
            set
            {
                _inventory = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public InventoryViewModel()
        {
            Inventory = new ObservableCollection<Product>
            {
                new Product { Name = "Laptop", Price = 999.99m, QuantityInStock = 10 },
                new Product { Name = "Smartphone", Price = 499.99m, QuantityInStock = 20 },
                new Product { Name = "Headphones", Price = 89.99m, QuantityInStock = 30 }
            };
        }
    }
}

