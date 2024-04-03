using FoodMaintenance.Interfaces;
using FoodMaintenance.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodMaintenance.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        #region Fields
        private readonly DbContext _DbContext;
        #endregion

        #region Properties
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public List<ProductTypeDTO> ProductTypes { get; set; } = new List<ProductTypeDTO>();
        public List<UnitOfMeasurementDTO> UnitsOfMeasurement { get; set; } = new List<UnitOfMeasurementDTO>();
        public ProductDTO? SelectedProduct { get; set; }
        public ProductDTO ProductToAdd { get; set; } = new ProductDTO() { IsActive = true };
        #endregion

        #region Commands
        public ICommand ReloadDataCommand { get; set; }
        public ICommand GetProductsCommand { get; set; }
        public ICommand GetProductTypesCommand { get; set; }
        public ICommand GetUnitsOfMeasurementCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand DeleteAllProductsCommand { get; set; }
        #endregion

        #region Constructors
        public ProductsViewModel(INavigationService NavigationService, DbContext DbContext)
            : base(NavigationService)
        {
            ReloadDataCommand = new RelayCommand(async () => { await ReloadData(); });
            GetProductsCommand = new RelayCommand(async () => { await GetProducts(); });
            GetProductTypesCommand = new RelayCommand(async () => { await GetProductTypes(); });
            GetUnitsOfMeasurementCommand = new RelayCommand(async () => { await GetUnitsOfMeasurement(); });
            AddProductCommand = new RelayCommand(async () => { await AddProduct(); });
            UpdateProductCommand = new RelayCommand(async () => { await UpdateProduct(); });
            DeleteProductCommand = new RelayCommand(async () => { await DeleteProduct(); });
            DeleteAllProductsCommand = new RelayCommand(async () => { await DeleteAllProducts(); });

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
        public async Task AddProduct()
        {
            await _DbContext.AddProduct(ProductToAdd);
            ProductToAdd = new ProductDTO() { IsActive = true };
            await ReloadData();
        }
        public async Task UpdateProduct()
        {
            if (SelectedProduct != null)
            {
                await _DbContext.UpdateProduct(SelectedProduct);
            }

            await ReloadData();
        }
        public async Task DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                await _DbContext.DeleteProduct(SelectedProduct.Id);
            }

            await ReloadData();
        }
        public async Task DeleteAllProducts()
        {
            await _DbContext.DeleteAllProducts();
            await ReloadData();
        }
        #endregion
    }
}
