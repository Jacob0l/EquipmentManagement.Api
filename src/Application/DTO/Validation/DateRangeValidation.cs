using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Validation
{
    public class DateRangeValidation : ValidationAttribute
    {

        private DateOnly startDate;
        private DateOnly endDate;

        public DateRangeValidation(string startDate, string endDate)
        {
            this.startDate = DateOnly.Parse(startDate);
            this.endDate = DateOnly.Parse(endDate);
        }


        protected override ValidationResult? IsValid(object? date, ValidationContext validationContext)
        {
            if (date is not DateOnly)
            {
                return new ValidationResult("Invalid format");
            }

            return (DateOnly)date >= startDate && (DateOnly)date <= endDate
                    ? ValidationResult.Success 
                    : new ValidationResult($"Date must be between {startDate} and {endDate}");
        }
    }
}
