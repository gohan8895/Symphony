using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.CustomAttributes
{
    public class StartDateAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"Start date must be today or after today.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var inputTime = ((DateTime)value);
            if (inputTime < DateTime.Now)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
