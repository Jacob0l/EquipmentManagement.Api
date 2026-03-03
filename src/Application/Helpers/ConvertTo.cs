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

        public static Calibration ToCalibrationModel(this CreateCalibrationRequest createCalibration, Equipment equipment)
        {
            return new Calibration
                (
                    date: createCalibration.Date,
                    companyName: createCalibration.CompanyName,
                    price: createCalibration.Price,
                    equipment: equipment
                );
        }

        public static CreateCalibrationResponse ToCalibrationResponse(this Calibration calibration)
        {
            return new CreateCalibrationResponse()
            {
                Id = calibration.Id,
                Date = calibration.Date,
                CompanyName = calibration.CompanyName,
                Price = calibration.Price,
                EquipmentId = calibration.EquipmentId
            };
        }

        public static CalibrationResponse ToCalibrationResponse(this Calibration calibration, EquipmentResponse equipment)
        {
            return new CalibrationResponse()
            {
                Id = calibration.Id,
                Date = calibration.Date,
                CompanyName = calibration.CompanyName,
                Price = calibration.Price,
                Equipment = equipment
            };
        }
    }
}
