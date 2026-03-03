using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.DTO;

using Application.Interfaces;

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

        [HttpPost]
        public async Task<IActionResult> CreateCalibration(CreateCalibrationRequest createCalibration)
        {
            var calibration = await this.calibrationService.CreateCalibration(createCalibration);

            return calibration.IsSuccess ? Ok(calibration.Value) : BadRequest(calibration.ErrorMessage);
        }
    }
}
