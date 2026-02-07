using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Interfaces;
using Application.DTO;
using Microsoft.AspNetCore.Mvc.Infrastructure;


namespace EquipmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {

        private IEquipmentService equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<EquipmentResponse>> GetEquipment(int id)
        {
            var result = await this.equipmentService.ReadEquipment(id);

            return result != null ? Ok(result) : BadRequest($"Equipment not found matching id {id}");
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<EquipmentResponse>>> GetAllEquipment()
        {
            var result = await this.equipmentService.ReadAllEquipment();

            return result != null ? Ok(result.ToList()) : BadRequest("Issue with list");
        }

        [HttpPost]
        public async Task<ActionResult<EquipmentResponse>> CreateEquipment(EquipmentRequest equipmentRequest)
        {
            var result = await this.equipmentService.CreateEquipment(equipmentRequest);
            return CreatedAtAction(nameof(GetEquipment),new {id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEquipment(UpdateEquipmentRequest updateEquipmentRequest)
        {
            var result = await this.equipmentService.UpdateEquipment(updateEquipmentRequest); //What if the id is not found, should have some error instead of just null. Null for now.

            return result != null ? Ok(result) : BadRequest($"Id {updateEquipmentRequest.Id} Not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            return await this.equipmentService.DeleteEquipment(id) ? NoContent() : BadRequest($"ID {id} not found in db");
        }
    }
}
