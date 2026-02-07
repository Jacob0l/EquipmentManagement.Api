using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UpdateEquipmentRequest : EquipmentRequest
    {
        /// <summary>
        /// The equipment Id which is unique for all equipment
        /// </summary>
        public int Id { get; set; }
    }
}
