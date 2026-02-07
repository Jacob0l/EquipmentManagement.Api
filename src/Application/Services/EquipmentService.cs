
using Application.DTO;
using Application.Interfaces;
using Application.Helpers;
using Core.Interfaces;

namespace Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private IEquipmentRepository equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository) 
        {
            this.equipmentRepository = equipmentRepository;
        }

        public async Task<EquipmentResponse> CreateEquipment(EquipmentRequest equipmentRequest)
        {
            var equipmentAdded = await equipmentRepository.CreateEquipment(equipmentRequest.ToEquipmentModel());
            return equipmentAdded.ToEquipmentResponse();
        }

        public async Task<bool> DeleteEquipment(int id)
        {
            return await equipmentRepository.DeleteEquipment(id);
        }

        public async Task<IEnumerable<EquipmentResponse>?> ReadAllEquipment()
        {
            return (await equipmentRepository.ReadAllEquipment()).Select(e => e.ToEquipmentResponse());
        }

        public async Task<EquipmentResponse?> ReadEquipment(int id)
        {
            var equipment = await this.equipmentRepository.ReadEquipment(id);
            return equipment != null ? equipment.ToEquipmentResponse() : null;
        }

        public async Task<EquipmentResponse?> UpdateEquipment(UpdateEquipmentRequest updateEquipmentRequest)
        {
            var equipmentoUpdate = updateEquipmentRequest.ToEquipmentModel();
            var updatedEquipment = await this.equipmentRepository.UpdateEquipment(equipmentoUpdate);
            return updatedEquipment != null ? updatedEquipment.ToEquipmentResponse() : null;
        }
    }
}
