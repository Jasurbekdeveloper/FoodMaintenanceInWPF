using System.Globalization;
using System.Windows.Controls;

namespace FoodMaintenance.ValidationRules
{
    /// <summary>
    /// A class providing validation related to an <see cref="object"/>.
    /// </summary>
    public class ObjectValidationRule : ValidationRule
    {
        public bool NullCheck { get; set; }
        public string? NullCheckErrorMessage { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (NullCheck && value == null) { return new ValidationResult(false, NullCheckErrorMessage ?? $"Must not be null."); }

            return new ValidationResult(true, null);
        }
    }
}

