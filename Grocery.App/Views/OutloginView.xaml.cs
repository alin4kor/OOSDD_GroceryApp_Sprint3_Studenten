using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class OutloginView : ContentPage
{
    private readonly GlobalViewModel _globalViewModel;
    private readonly LoginViewModel _loginViewModel;
    public OutloginView (GlobalViewModel globalViewModel, LoginViewModel loginViewModel)
    {
        InitializeComponent();
        _globalViewModel = globalViewModel;
        _loginViewModel = loginViewModel;
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        _globalViewModel.Client = null;
        Application.Current.MainPage = new LoginView(_loginViewModel);
    }
}
