using Grocery.App.ViewModels;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;

namespace Grocery.App
{
    public partial class AppShell : Shell
    {
        private readonly GlobalViewModel _globalViewModel;
        public AppShell(GlobalViewModel globalViewModel)
        {
            InitializeComponent();
            _globalViewModel = globalViewModel;
            Routing.RegisterRoute(nameof(GroceryListItemsView), typeof(GroceryListItemsView));
            Routing.RegisterRoute(nameof(ProductView), typeof(ProductView));
            Routing.RegisterRoute(nameof(ChangeColorView), typeof(ChangeColorView));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(GroceryListsView), typeof(GroceryListsView));
            NavigateToInitialPage();
        }

        private async void NavigateToInitialPage()
        {
            try
            {
                await Task.Delay(100);
                if (_globalViewModel.Client != null)
                {
                    await Current.GoToAsync("//GroceryListsView");
                }
                else
                {
                    await Current.GoToAsync("//LoginView");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
            }
        }
    }
}
