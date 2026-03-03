using Application.Helpers;
using Application.Interfaces;
using Application.DTO;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class CalibrationService : ICalibrationService
    {

        private ICalibrationRepository  calibrationRepository;
        private IEquipmentRepository equipmentRepository;

        public CalibrationService(ICalibrationRepository calibrationRepository, IEquipmentRepository equipmentRepository)
        {
            this.calibrationRepository = calibrationRepository;
            this.equipmentRepository = equipmentRepository;
        }

        public async Task<Result<CreateCalibrationResponse>> CreateCalibration(CreateCalibrationRequest createCalibration)
        {
            Calibration calibration;
            var equipment = await this.equipmentRepository.ReadEquipment(createCalibration.EquipmentId);

            if (equipment == null)
                return Result<CreateCalibrationResponse>.Failure($"There is no matching equipment with the id {createCalibration.EquipmentId}");

            try
            {
                calibration = await this.calibrationRepository.CreateCalibration(createCalibration.ToCalibrationModel(equipment));
            }
            catch (Exception ex)
            {
                return Result<CreateCalibrationResponse>.Failure(ex.ToString());
            }


            return Result<CreateCalibrationResponse>.Success(calibration.ToCalibrationResponse());
        }

        public async Task<Result<CalibrationResponse>> GetCalibration(int id)
        {

            Calibration? calibration;

            try
            {
                calibration = await this.calibrationRepository.ReadCalibration(id);
            }
            catch (Exception ex)
            {
                return Result<CalibrationResponse>.Failure(ex.ToString());
            }

            return calibration != null 
                ? Result<CalibrationResponse>.Success(calibration.ToCalibrationResponse(calibration.Equipment.ToEquipmentResponse()))
                : Result<CalibrationResponse>.Failure($"No Calibration found with id {id}");
        }
    }
}
