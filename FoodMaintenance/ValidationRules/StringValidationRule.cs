using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace FoodMaintenance.ValidationRules
{
    /// <summary>
    /// A class providing validation related to a <see cref="string"/>.
    /// </summary>
    public class StringValidationRule : ValidationRule
    {
        public bool NullOrEmptyCheck { get; set; }
        public string? NullOrEmptyErrorMessage { get; set; }
        public bool NullOrWhiteSpaceCheck { get; set; }
        public string? NullOrWhiteSpaceErrorMessage { get; set; }
        public int? MinCharacterCount { get; set; }
        public string? MinCharacterCountErrorMessage { get; set; }
        public int? MaxCharacterCount { get; set; }
        public string? MaxCharacterCountErrorMessage { get; set; }
        public string? RegexPattern{ get; set; }
        public string? RegexPatternErrorMessage { get; set; }
      /*  public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string? ValueString = value as string;

            if (NullOrEmptyCheck && string.IsNullOrEmpty(ValueString)) { return new ValidationResult(false, NullOrEmptyErrorMessage ?? $"Must not be empty."); }
            if (NullOrWhiteSpaceCheck && string.IsNullOrWhiteSpace(ValueString)){ return new ValidationResult(false, NullOrWhiteSpaceErrorMessage ?? $"Must not be whitespace."); }

            if (ValueString.Length < MinCharacterCount)
            {
                bool Plural = MinCharacterCount != 1;
                return new ValidationResult(false, MinCharacterCountErrorMessage ?? $"Minimum of {MinCharacterCount} character{(Plural ? "s" : "")}.");
            }
            if (ValueString.Length > MaxCharacterCount)
            {
                bool Plural = MaxCharacterCount != 1;
                return new ValidationResult(false, MaxCharacterCountErrorMessage ?? $"Minimum of {MaxCharacterCount} character{(Plural ? "s" : "")}.");
            }

            if (!string.IsNullOrEmpty(RegexPattern) && !Regex.IsMatch(ValueString, RegexPattern))
            {
                return new ValidationResult(false, RegexPatternErrorMessage ?? "Invalid Format.");
            }

            return new ValidationResult(true, null);
        }*/
    }
}
