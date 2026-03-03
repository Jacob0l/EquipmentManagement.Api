using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CreateCalibrationResponse
    {
        /// <summary>
        /// The calibration Id which is unique for all calibrations.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// The date of the calibration.
        /// </summary>
        public DateOnly Date { get; init; }


        /// <summary>
        /// The cost of the calibration
        /// </summary>
        public decimal Price { get; init; }

        /// <summary>
        /// The company which is performing the calibration.
        /// </summary>
        public required string CompanyName { get; init; }

        /// <summary>
        /// The Equipment id.
        /// </summary>
        public int EquipmentId { get; init; }
    }
}
