using System;
using Prism.Navigation;

namespace ClassifiedApp2.ViewModels
{
    public class Tab4ProfilePageViewModel : ViewModelTabsBase
    {
        public Tab4ProfilePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Profile Page";
        }
    }
}
