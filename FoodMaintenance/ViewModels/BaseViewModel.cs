using FoodMaintenance.Interfaces;
using PropertyChanged;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FoodMaintenance.ViewModels
{
    /// <summary>
    /// Base implementation of a ViewModel implementing <see cref="INotifyPropertyChanged"/> and injected with a <see cref="INavigationService"/>.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Properties
        public BaseViewModel? CurrentViewModel
        {
            get
            {
                return NavigationService.CurrentViewModel;
            }
        }
        protected INavigationService NavigationService { get; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Constructors
        public BaseViewModel(INavigationService NavigationService)
        {
            this.NavigationService = NavigationService ??
                throw new ArgumentNullException(nameof(NavigationService));
            NavigationService.Navigated += NavigationService_Navigated;
        }
        #endregion

        #region Methods
        protected virtual void NavigationService_Navigated(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public void Dispose()
        {
            NavigationService.Navigated -= NavigationService_Navigated;
        }
        #endregion
    }
}
