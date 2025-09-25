using Grocery.App.ViewModels;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;

namespace Grocery.App
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly GlobalViewModel _globalViewModel;
        public App(GlobalViewModel globalViewModel, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _globalViewModel = globalViewModel;

            //MainPage = new AppShell();
            //MainPage = new LoginView(viewModel);
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine($"Unhandled Exception: {args.ExceptionObject}");
            };

            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine($"Unobserved Task Exception: {args.Exception}");
            };

            if (_globalViewModel.Client != null)
            {
                MainPage = new AppShell(_globalViewModel);
            }
            else
            {
                var loginViewModel = _serviceProvider.GetService<LoginViewModel>();
                MainPage = new LoginView(loginViewModel);
            }

            _serviceProvider = serviceProvider;
        }
    }
}
