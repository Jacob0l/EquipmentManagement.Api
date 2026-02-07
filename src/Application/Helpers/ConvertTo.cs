using Application.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class ConvertTo
    {
        public static Equipment ToEquipmentModel(this EquipmentRequest equipmentRequest)
        {
            var equipment = new Equipment()
            {
                Category = equipmentRequest.Category,
                Type = equipmentRequest.Type,
                Manufacturer = equipmentRequest.Manufacturer,
                Model = equipmentRequest.Model,
                SN = equipmentRequest.SN,
            };

            if (equipmentRequest is UpdateEquipmentRequest updateEquipmentRequest)
            {
                equipment.Id = updateEquipmentRequest.Id;
            }

            return equipment;
        }

        public static EquipmentResponse ToEquipmentResponse(this Equipment equipment)
        {
            return new EquipmentResponse()
            {
                Id = equipment.Id,
                Category = equipment.Category,
                Type = equipment.Type,
                Manufacturer = equipment.Manufacturer,
                Model = equipment.Model,
                SN = equipment.SN,
            };
        }
    }
}
