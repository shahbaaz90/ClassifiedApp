using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ClassifiedApp2.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private ICommand goToHomePageCommand;
        public ICommand GoToHomePageCommand
        {
            get
            {
                goToHomePageCommand = goToHomePageCommand ?? new DelegateCommand(GoToHomePage);
                return goToHomePageCommand;
            }
        }

        private async void GoToHomePage()
        {
            await NavigationService.NavigateAsync(
                new Uri("/NavigationPage/RootTabbedPage?selectedTab=Tab1HomePage",
                        UriKind.Absolute));
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
