using FoodMaintenance.Interfaces;
using FoodMaintenance.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodMaintenance.ViewModels
{
    public class UnitsOfMeasurementViewModel : BaseViewModel
    {
        #region Fields
        private readonly DbContext _DbContext;
        #endregion

        #region Properties
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public List<ProductTypeDTO> ProductTypes { get; set; } = new List<ProductTypeDTO>();
        public List<UnitOfMeasurementDTO> UnitsOfMeasurement { get; set; } = new List<UnitOfMeasurementDTO>();
        public UnitOfMeasurementDTO? SelectedUnitOfMeasurement { get; set; }
        public UnitOfMeasurementDTO UnitOfMeasurementToAdd { get; set; } = new UnitOfMeasurementDTO();
        #endregion

        #region Commands
        public ICommand ReloadDataCommand { get; set; }
        public ICommand GetProductsCommand { get; set; }
        public ICommand GetProductTypesCommand { get; set; }
        public ICommand GetUnitsOfMeasurementCommand { get; set; }
        public ICommand AddUnitOfMeasurementCommand { get; set; }
        public ICommand UpdateUnitOfMeasurementCommand { get; set; }
        public ICommand DeleteUnitOfMeasurementCommand { get; set; }
        public ICommand DeleteAllUnitsOfMeasurementCommand { get; set; }
        #endregion

        #region Constructors
        public UnitsOfMeasurementViewModel(INavigationService NavigationService, DbContext DbContext)
            : base(NavigationService)
        {
            ReloadDataCommand = new RelayCommand(async () => { await ReloadData(); });
            GetProductsCommand = new RelayCommand(async () => { await GetProducts(); });
            GetProductTypesCommand = new RelayCommand(async () => { await GetProductTypes(); });
            GetUnitsOfMeasurementCommand = new RelayCommand(async () => { await GetUnitsOfMeasurement(); });
            AddUnitOfMeasurementCommand = new RelayCommand(async () => { await AddUnitOfMeasurement(); });
            UpdateUnitOfMeasurementCommand = new RelayCommand(async () => { await UpdateUnitOfMeasurement(); });
            DeleteUnitOfMeasurementCommand = new RelayCommand(async () => { await DeleteUnitOfMeasurement(); });
            DeleteAllUnitsOfMeasurementCommand = new RelayCommand(async () => { await DeleteAllUnitsOfMeasurement(); });

            _DbContext = DbContext;
        }
        #endregion

        #region Methods
        public async Task ReloadData()
        {
            await GetProducts();
            await GetProductTypes();
            await GetUnitsOfMeasurement();
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
        public async Task AddUnitOfMeasurement()
        {
            await _DbContext.AddUnitOfMeasurement(UnitOfMeasurementToAdd);
            UnitOfMeasurementToAdd = new UnitOfMeasurementDTO();

            await ReloadData();
        }
        public async Task UpdateUnitOfMeasurement()
        {
            if (SelectedUnitOfMeasurement != null)
            {
                await _DbContext.UpdateUnitOfMeasurement(SelectedUnitOfMeasurement);
            }

            await ReloadData();
        }
        public async Task DeleteUnitOfMeasurement()
        {
            if (SelectedUnitOfMeasurement != null)
            {
                await _DbContext.DeleteUnitOfMeasurement(SelectedUnitOfMeasurement);
            }

            await ReloadData();
        }
        public async Task DeleteAllUnitsOfMeasurement()
        {
            await _DbContext.DeleteAllUnitsOfMeasurement();
            await ReloadData();
        }
        #endregion
    }
}
