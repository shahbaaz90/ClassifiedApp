using System;
using Prism;
using Prism.Navigation;

namespace ClassifiedApp2.ViewModels
{
    public class ViewModelTabsBase : ViewModelBase, IActiveAware
    {
        public ViewModelTabsBase(INavigationService navigationService) : base(navigationService)
        {
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { SetProperty(ref isActive, value, RaiseIsActiveChanged); }
        }

        public event EventHandler IsActiveChanged;

        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
