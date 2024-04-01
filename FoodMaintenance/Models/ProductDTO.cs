namespace FoodMaintenance.Models
{
    public class ProductDTO : BaseObservableModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ProductTypeDTO? Type { get; set; }
        public float MinStockQuantity { get; set; }
        public UnitOfMeasurementDTO? UnitOfMeasurement { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
