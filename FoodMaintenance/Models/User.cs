using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FoodMaintenance.Models
{
    [Table("Users")]
    public class User
    {
        #region Properties
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        [NotNull]
        public string? Name { get; set; }

       [NotNull]
        public string? Login { get; set; }

       [NotNull]
        public string? Parol { get; set; }
       
        [NotNull]
        public bool IsActive { get; set; }
        #endregion
    }
}