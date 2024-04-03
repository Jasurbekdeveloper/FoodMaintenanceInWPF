namespace FoodMaintenance.Models
{
    public class ProductDTO : BaseObservableModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public ProductTypeDTO? Type { get; set; }
        public string? Url { get; set; }
        public UnitOfMeasurementDTO? UnitOfMeasurement { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
