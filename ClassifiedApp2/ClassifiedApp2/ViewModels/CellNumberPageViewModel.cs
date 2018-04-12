using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;

namespace ClassifiedApp2.ViewModels
{
    public class CellNumberPageViewModel : ViewModelBase
    {
        public CellNumberPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoToHomePageCommand = new DelegateCommand(async () => await GoToHomePage());
        }

        private async Task GoToHomePage()
        {
            await NavigationService.NavigateAsync(
                new Uri("/NavigationPage/RootTabbedPage?selectedTab=Tab1HomePage",
                        UriKind.Absolute));
        }

        public ICommand GoToHomePageCommand { get; private set; }
    }
}
