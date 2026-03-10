using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTO.Validation;

namespace Application.DTO
{
    public class DateRange
    {
        [DateRangeValidation("2024-01-01", "2028-01-01")]
        public DateOnly startDate {  get; set; }

        [DateRangeValidation("2024-01-01", "2028-12-31")]
        public DateOnly endDate { get; set; }
    }
}
