using System;
using Prism;
using Prism.Navigation;

namespace ClassifiedApp2.ViewModels
{
    public class Tab1HomePageViewModel : ViewModelTabsBase
    {
        public Tab1HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Home Page";
        }

        async void GoHome()
        {
            await NavigationService.NavigateAsync(new Uri($"HomePage", UriKind.Relative), null, false);
        }
    }
}
