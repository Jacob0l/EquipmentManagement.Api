using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class EquipmentRequest
    {
        /// <summary>
        /// The Category of the Equipment (Electrical, Mechanical..)
        /// </summary>
        public required string Category { get; set; }

        /// <summary>
        /// The Type of the Equipment (Electrical:Oscilloscope)
        /// </summary>
        public required string Type { get; set; }

        /// <summary>
        /// The Manufacturer of the Equipment
        /// </summary>
        public required string Manufacturer { get; set; }

        /// <summary>
        /// The Model of the Equipment
        /// </summary>
        public required string Model { get; set; }

        /// <summary>
        /// The SN of the Equipment
        /// </summary>
        public required string SN { get; set; }
    }
}
