using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using okiraPrism.Resx;

namespace okiraPrism.ViewModels
{
    
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ICommand NavigateCommand { get; set; }
        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("ArticleCard");
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = AppResources.MainPage_Title;
            _navigationService = NavigationService;
            NavigateCommand = new DelegateCommand(NavigateAction);
        }

        private async void NavigateAction()
        {
            await _navigationService.NavigateAsync("NavigationPage/ArticleCardPage");
        }
    }
}
