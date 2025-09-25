using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class OutloginViewModel : BaseViewModel
    {
        private readonly GlobalViewModel _globalViewModel;


        public OutloginViewModel(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        

    }
}

