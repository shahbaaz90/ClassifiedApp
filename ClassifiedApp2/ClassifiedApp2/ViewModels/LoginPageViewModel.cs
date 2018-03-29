using System;
using System.Windows.Input;
using ClassifiedApp2.Models;
using ClassifiedApp2.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace ClassifiedApp2.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        readonly IFacebookManager facebookManager;
        readonly IPageDialogService dialogService;

        public LoginPageViewModel(INavigationService navigationService,
                                  IFacebookManager facebookManager,
                                  IPageDialogService dialogService) : base(navigationService)
        {
            Title = "Main Page";

            this.dialogService = dialogService;
            this.facebookManager = facebookManager;

            IsLoggedIn = false;
            FacebookLoginCommand = new DelegateCommand(FacebookLogin);
            FacebookLogoutCommand = new DelegateCommand(FacebookLogout);
        }

        private void FacebookLogout()
        {
            facebookManager.Logout();
            IsLoggedIn = false;
        }

        private void FacebookLogin()
        {
            facebookManager.Login(OnLoginComplete);
        }

        private void OnLoginComplete(FacebookUser fbUser, string message)
        {
            if (fbUser != null)
            {
                FacebookUser = fbUser;
                IsLoggedIn = true;
            }
            else
            {
                dialogService.DisplayAlertAsync("Error", message, "Ok");
            }
        }

        private bool isLoggedIn;
        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set { SetProperty(ref isLoggedIn, value); }
        }

        public ICommand FacebookLoginCommand { get; private set; }
        public ICommand FacebookLogoutCommand { get; private set; }

        private FacebookUser facebookUser;
        public FacebookUser FacebookUser
        {
            get { return facebookUser; }
            set { SetProperty(ref facebookUser, value); }
        }

        private string hello;
        public string Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }

    }
}
