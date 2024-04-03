using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FoodMaintenance.Models
{
    [Table("Products")]
    public class Product
    {
        #region Properties
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        [NotNull]
        public string? Name { get; set; }
        [NotNull]
        public decimal Price { get; set; }
        [ForeignKey(typeof(ProductType))]
        public int TypeId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public ProductType? Type { get; set; }
        [NotNull]
        public string? Url { get; set; }
        [ForeignKey(typeof(UnitOfMeasurement))]
        public int UnitOfMeasurementId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public UnitOfMeasurement? UnitOfMeasurement { get; set; }
        [NotNull]
        public bool IsActive { get; set; }
        #endregion
    }
}