using FoodMaintenance.Interfaces;
using FoodMaintenance.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;

namespace FoodMaintenance.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields
        private readonly DbContext _DbContext;
        private readonly DashboardViewModel _DashboardViewModel;
        private readonly ProductsViewModel _ProductsViewModel;
        private readonly ProductTypesViewModel _ProductTypesViewModel;
        private readonly UnitsOfMeasurementViewModel _UnitsOfMeasurementViewModel;
        #endregion

        #region Properties
        public WindowState WindowState { get; set; } = WindowState.Maximized;
        #endregion

        #region Commands
        public ICommand ShowDashboardCommand { get; set; }
        public ICommand ShowProductsCommand { get; set; }
        public ICommand ShowProductTypesCommand { get; set; }
        public ICommand ShowUnitsOfMeasurementCommand { get; set; }
        public ICommand ChangeWindowStateCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        #endregion

        #region Constructors
        public MainViewModel(INavigationService NavigationService, DbContext DbContext)
            :base(NavigationService)
        {
            ShowDashboardCommand = new RelayCommand(ShowDashboard);
            ShowProductsCommand = new RelayCommand(ShowProducts);
            ShowProductTypesCommand = new RelayCommand(ShowProductTypes);
            ShowUnitsOfMeasurementCommand = new RelayCommand(ShowUnitsOfMeasurement);
            ChangeWindowStateCommand = new RelayCommand<WindowState>(ChangeWindowState);
            CloseWindowCommand = new RelayCommand<Window?>(CloseWindow);

            _DbContext = DbContext;
            _DashboardViewModel = new DashboardViewModel(NavigationService, _DbContext);
            _ProductsViewModel = new ProductsViewModel(NavigationService, _DbContext);
            _ProductTypesViewModel = new ProductTypesViewModel(NavigationService, _DbContext);
            _UnitsOfMeasurementViewModel = new UnitsOfMeasurementViewModel(NavigationService, _DbContext);


            ShowDashboard();
        }
        #endregion

        #region Methods
        public void ShowDashboard()
        {
            NavigationService.Navigate(_DashboardViewModel);
        }
        public void ShowProducts()
        {
            NavigationService.Navigate(_ProductsViewModel);
        }
        public void ShowProductTypes()
        {
            NavigationService.Navigate(_ProductTypesViewModel);
        }
        public void ShowUnitsOfMeasurement()
        {
            NavigationService.Navigate(_UnitsOfMeasurementViewModel);
        }
        public void ChangeWindowState(WindowState WindowState)
        {
            this.WindowState = WindowState;
        }
        public void CloseWindow(Window? Window)
        {
            Window?.Close();
        }
        #endregion
    }
}
