using FoodMaintenance.Interfaces;
using FoodMaintenance.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodMaintenance.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        #region Fields
        private readonly DbContext _DbContext;
        #endregion

        #region Properties
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public List<ProductTypeDTO> ProductTypes { get; set; } = new List<ProductTypeDTO>();
        public List<UnitOfMeasurementDTO> UnitsOfMeasurement { get; set; } = new List<UnitOfMeasurementDTO>();
        public List<ProductDTO> DummyProducts { get; set; } = new List<ProductDTO>()
        {
            new ProductDTO(),
            new ProductDTO(),
            new ProductDTO(),
            new ProductDTO(),
            new ProductDTO(),
            new ProductDTO(),
            new ProductDTO(),
            new ProductDTO(),
            new ProductDTO(),
            new ProductDTO(),
            new ProductDTO(),
            new ProductDTO(),
        };
        public bool IsLoadingData { get; set; }

        #endregion

        #region Commands
        public ICommand GetProductsCommand { get; set; }
        public ICommand GetProductTypesCommand { get; set; }
        public ICommand GetUnitsOfMeasurementCommand { get; set; }
        public ICommand ReloadDataCommand { get; set; }
        #endregion

        #region Constructors
        public DashboardViewModel(INavigationService NavigationService, DbContext DbContext)
            : base(NavigationService)
        {
            //Didn't use AsyncRelayCommand because it eats exceptions.
            GetProductsCommand = new RelayCommand(async () => { await GetProducts(); });
            GetProductTypesCommand = new RelayCommand(async () => { await GetProductTypes(); });
            GetUnitsOfMeasurementCommand = new RelayCommand(async () => { await GetUnitsOfMeasurement(); });
            ReloadDataCommand = new RelayCommand(async () => { await ReloadData(); }, canExecute: () => { return !IsLoadingData; });

            _DbContext = DbContext;
        }
        #endregion

        #region Methods
        public async Task ReloadData()
        {
            IsLoadingData = true;
            //Default delay to simulate loading.
            await Task.Delay(750);
            await GetProducts();
            await GetProductTypes();
            await GetUnitsOfMeasurement();
            IsLoadingData = false;
        }
        public async Task GetProducts()
        {
            Products = await _DbContext.GetProducts();
        }
        public async Task GetProductTypes()
        {
            ProductTypes = await _DbContext.GetProductTypes();
        }
        public async Task GetUnitsOfMeasurement()
        {
            UnitsOfMeasurement = await _DbContext.GetUnitsOfMeasurement();
        }
        #endregion
    }
}
