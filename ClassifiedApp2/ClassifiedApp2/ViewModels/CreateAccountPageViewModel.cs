using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;

namespace ClassifiedApp2.ViewModels
{
    public class CreateAccountPageViewModel : ViewModelBase
    {
        public CreateAccountPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Create Account";

            GoToBusinessSelectCommand = new DelegateCommand(GoToBusiness);
        }

        private async void GoToBusiness()
        {
            await NavigationService.NavigateAsync("BusinessSelectionPage");
        }

        public ICommand GoToBusinessSelectCommand { get; private set; }
    }
}
