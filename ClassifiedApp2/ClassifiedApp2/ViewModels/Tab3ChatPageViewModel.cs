using System;
using Prism.Navigation;

namespace ClassifiedApp2.ViewModels
{
    public class Tab3ChatPageViewModel : ViewModelTabsBase
    {
        public Tab3ChatPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Chat Page";
        }
    }
}
