using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ClassifiedApp2.Services;
using Prism.Commands;
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

            NextCommand = new DelegateCommand(async () => await MoveToCellNumberPage());
        }

        private async Task MoveToCellNumberPage()
        {
            await NavigationService.NavigateAsync("CellNumberPage");
        }

        public ICommand NextCommand { get; private set; }

    }
}
