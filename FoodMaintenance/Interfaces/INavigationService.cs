using FoodMaintenance.ViewModels;
using System;

namespace FoodMaintenance.Interfaces
{
    /// <summary>
    /// An interface for service providing methods to navigate between ViewModels.
    /// </summary>
    public interface INavigationService
    {
        #region Properties
        BaseViewModel? CurrentViewModel { get; }
        #endregion

        #region Events
        event EventHandler? Navigated;
        #endregion

        #region Methods
        void Navigate(BaseViewModel? ViewModel);
        #endregion
    }
}
