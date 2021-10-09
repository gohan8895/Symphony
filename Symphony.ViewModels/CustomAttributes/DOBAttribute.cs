using System;
using System.ComponentModel.DataAnnotations;

namespace Symphony.ViewModels.CustomAttributes
{
    public class DOBAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"Sorry, Student must be 16 years or older";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var inputTime = ((DateTime)value);
            if (DateTime.UtcNow.Year - inputTime.Year < 16)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
