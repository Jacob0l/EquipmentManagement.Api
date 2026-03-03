using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CreateCalibrationRequest
    {
        /// <summary>
        /// The id of the equipment for this calibration
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="The EquipmentId must be greater than 0.") ]
        public int EquipmentId { get; set; }


        /// <summary>
        /// The date of calibration.
        /// </summary>
        [Required]
        public DateOnly Date {  get; set; }

        /// <summary>
        /// The company which is performing the calibration.
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters.")]
        public required string CompanyName { get; set; }


        // <summary>
        /// The cost of the calibration
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price can have at most 2 decimal places.")]
        public decimal Price { get; set; }

    }
}
