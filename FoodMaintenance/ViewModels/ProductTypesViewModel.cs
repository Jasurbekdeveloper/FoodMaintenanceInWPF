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
    public class ProductTypesViewModel : BaseViewModel
    {
        #region Fields
        private readonly DbContext _DbContext;
        #endregion

        #region Properties
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public List<ProductTypeDTO> ProductTypes { get; set; } = new List<ProductTypeDTO>();
        public List<UnitOfMeasurementDTO> UnitsOfMeasurement { get; set; } = new List<UnitOfMeasurementDTO>();
        public ProductTypeDTO? SelectedProductType { get; set; }
        public ProductTypeDTO ProductTypeToAdd { get; set; } = new ProductTypeDTO();
        #endregion

        #region Commands
        public ICommand ReloadDataCommand { get; set; }
        public ICommand GetProductsCommand { get; set; }
        public ICommand GetProductTypesCommand { get; set; }
        public ICommand GetUnitsOfMeasurementCommand { get; set; }
        public ICommand AddProductTypeCommand { get; set; }
        public ICommand UpdateProductTypeCommand { get; set; }
        public ICommand DeleteProductTypeCommand { get; set; }
        public ICommand DeleteAllProductTypesCommand { get; set; }
        #endregion

        #region Constructors
        public ProductTypesViewModel(INavigationService NavigationService, DbContext DbContext)
            : base(NavigationService)
        {
            ReloadDataCommand = new RelayCommand(async () => { await ReloadData(); });
            GetProductsCommand = new RelayCommand(async () => { await GetProducts(); });
            GetProductTypesCommand = new RelayCommand(async () => { await GetProductTypes(); });
            GetUnitsOfMeasurementCommand = new RelayCommand(async () => { await GetUnitsOfMeasurement(); });
            AddProductTypeCommand = new RelayCommand(async () => { await AddProductType(); });
            UpdateProductTypeCommand = new RelayCommand(async () => { await UpdateProductType(); });
            DeleteProductTypeCommand = new RelayCommand(async () => { await DeleteProductType(); });
            DeleteAllProductTypesCommand = new RelayCommand(async () => { await DeleteAllProductTypes(); });

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
        public async Task AddProductType()
        {
            await _DbContext.AddProductType(ProductTypeToAdd);
            ProductTypeToAdd = new ProductTypeDTO();

            await ReloadData();
        }
        public async Task UpdateProductType()
        {
            if (SelectedProductType != null)
            {
                await _DbContext.UpdateProductType(SelectedProductType);
            }

            await ReloadData();
        }
        public async Task DeleteProductType()
        {
            if (SelectedProductType != null)
            {
                await _DbContext.DeleteProductType(SelectedProductType);
            }

            await ReloadData();
        }
        public async Task DeleteAllProductTypes()
        {
            await _DbContext.DeleteAllProductTypes();
            await ReloadData();
        }
        #endregion
    }
}
