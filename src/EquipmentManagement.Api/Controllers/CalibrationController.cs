using Application.DTO;
using Application.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalibrationController : ControllerBase
    {

        private ICalibrationService calibrationService;

        public CalibrationController(ICalibrationService calibrationService)
        {
            this.calibrationService = calibrationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalibration(int id)
        {
            var calibration = await this.calibrationService.GetCalibration(id);

            return calibration.IsSuccess ? Ok(calibration.Value) : BadRequest(calibration.ErrorMessage);
        }

        [HttpGet]
        public async Task<IActionResult> GetCalibrationByCategory([FromQuery]DateRange dateRange)
        {
            var calibrationDictionary = await this.calibrationService.GetCalibrationsByEquipmentCategory(dateRange);

            return calibrationDictionary.IsSuccess ? Ok(calibrationDictionary.Value) : BadRequest(calibrationDictionary.ErrorMessage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCalibration(CreateCalibrationRequest createCalibration)
        {
            var calibration = await this.calibrationService.CreateCalibration(createCalibration);

            return calibration.IsSuccess ? Ok(calibration.Value) : BadRequest(calibration.ErrorMessage);
        }


    }
}
