using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Nanny.WebApi.Attributes
{
    public class ValidateDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (!(value is DateTime))
                {
                    return new ValidationResult("date_out_of_range");
                }

                try
                {
                    new SqlDateTime((DateTime) value);
                }
                catch
                {
                    return new ValidationResult("date_out_of_range");
                }
            }

            return ValidationResult.Success;
        }
    }
}