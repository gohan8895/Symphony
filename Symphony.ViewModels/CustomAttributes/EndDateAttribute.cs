using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.CustomAttributes
{
    public class EndDateAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public EndDateAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        public string GetErrorMessage() =>
            $"End date must be greater than start date. Please try again!";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            // Get the current input date
            var inputTime = ((DateTime)value);

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property is null) throw new ArgumentException("Property with this name not found.");

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (inputTime < comparisonValue)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
