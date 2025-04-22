using Maui.eCommerce.Views;

namespace Maui.eCommerce
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InventoryPage());

            Routing.RegisterRoute("inventory", typeof(InventoryPage));
            Routing.RegisterRoute("cart", typeof(CartPage));
            Routing.RegisterRoute("checkout", typeof(CheckoutPage));
        }
    }
}

