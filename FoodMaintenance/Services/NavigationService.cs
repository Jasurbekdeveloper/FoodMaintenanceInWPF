using FoodMaintenance.Interfaces;
using FoodMaintenance.ViewModels;
using System;

namespace FoodMaintenance.Services
{
    /// <summary>
    /// A service providing methods to navigate between ViewModels.
    /// </summary>
    public class NavigationService : INavigationService
    {
        #region Properties
        public BaseViewModel? CurrentViewModel { get; private set; }
        #endregion

        #region Events
        public event EventHandler? Navigated;
        #endregion

        #region Methods
        protected void OnNavigated()
        {
            Navigated?.Invoke(this, EventArgs.Empty);
        }
        public void Navigate(BaseViewModel? ViewModel)
        {
            if (CurrentViewModel != ViewModel)
            {
                //Dispose old ViewModel to prevent memory leaks.
                CurrentViewModel?.Dispose();
                CurrentViewModel = ViewModel;
                OnNavigated();
            }
        }
        #endregion
    }
}
