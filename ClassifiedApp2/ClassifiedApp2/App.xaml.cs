using Prism;
using Prism.Ioc;
using ClassifiedApp2.ViewModels;
using ClassifiedApp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;
using ClassifiedApp2.Common.Services;
using ClassifiedApp2.Services;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ClassifiedApp2
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            this.InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/LoginPage");

            await NavigationService.NavigateAsync(
                 new Uri("/NavigationPage/RootTabbedPage?selectedTab=Tab1HomePage",
                         UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<BusinessSelectionPage>();
            containerRegistry.RegisterForNavigation<CellNumberPage>();
            containerRegistry.RegisterForNavigation<CreateAccountPage>();

            containerRegistry.RegisterForNavigation<RootTabbedPage>();
            containerRegistry.RegisterForNavigation<Tab1HomePage, Tab1HomePageViewModel>();
            containerRegistry.RegisterForNavigation<Tab2AlertsPage>();
            containerRegistry.RegisterForNavigation<Tab3ChatPage>();
            containerRegistry.RegisterForNavigation<Tab4ProfilePage>();

            containerRegistry.Register<ICacheService, CacheService>();
        }
    }
}
