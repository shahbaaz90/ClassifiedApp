using System;
using Prism;
using Prism.Navigation;

namespace ClassifiedApp2.ViewModels
{
    public class Tab1HomePageViewModel : ViewModelTabsBase
    {
        public Tab1HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        async void GoHome()
        {
            await NavigationService.NavigateAsync(new Uri($"HomePage", UriKind.Relative), null, false);
        }
    }
}
