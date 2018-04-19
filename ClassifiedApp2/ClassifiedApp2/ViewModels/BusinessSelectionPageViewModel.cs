using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ClassifiedApp2.Common.Models;
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

            NextCommand = new DelegateCommand(MoveToCellNumberPage);

            PopulateCustomerPicker();
        }

        private bool isIndividual = true;
        public bool IsIndividual
        {
            get { return isIndividual; }
            set
            {
                if (IsIndividual != value)
                {
                    SetProperty(ref isIndividual, value);
                    RaisePropertyChanged("IsBusiness");
                }
            }
        }

        public bool IsBusiness
        {
            get { return !isIndividual; }
            set
            {
                if (isIndividual != value)
                {
                    SetProperty(ref isIndividual, !value);
                    RaisePropertyChanged("IsIndividual");
                }
            }
        }

        private async void MoveToCellNumberPage()
        {
            await NavigationService.NavigateAsync("CellNumberPage");
        }

        public ICommand NextCommand { get; private set; }

        private PickerItem selectedCustomerType;
        public PickerItem SelectedCustomerType
        {
            get { return selectedCustomerType; }
            set { SetProperty(ref selectedCustomerType, value); }
        }

        private ObservableCollection<PickerItem> pickerCustomerType;
        public ObservableCollection<PickerItem> PickerCustomerType
        {
            get { return pickerCustomerType; }
            set { SetProperty(ref pickerCustomerType, value); }
        }


        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        private void PopulateCustomerPicker()
        {
            PickerCustomerType = new ObservableCollection<PickerItem>()
            {
                new PickerItem{ Value = 0, DisplayName = "AS AN INDIVIDUAL" },
                new PickerItem{ Value = 1, DisplayName = "AS A BUSINESS" }
            };
            SelectedCustomerType = PickerCustomerType[0];
        }
    }
}
