using System;
using Prism.Navigation;

namespace ClassifiedApp2.ViewModels
{
    public class CreateAccountPageViewModel : ViewModelBase
    {
        public CreateAccountPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Create Account";
        }
    }
}
