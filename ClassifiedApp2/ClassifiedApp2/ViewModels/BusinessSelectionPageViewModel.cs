using System;
using ClassifiedApp2.Services;
using Prism.Navigation;
using Prism.Services;

namespace ClassifiedApp2.ViewModels
{
    public class BusinessSelectionPageViewModel : ViewModelBase
    {
        public BusinessSelectionPageViewModel(INavigationService navigationService,
                                              IPageDialogService dialogService) : base(navigationService)
        {
            Title = "Setup";
        }
    }
}
