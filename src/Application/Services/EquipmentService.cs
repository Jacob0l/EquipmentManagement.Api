
using Application.DTO;
using Application.Interfaces;
using Application.Helpers;
using Core.Interfaces;
using Core.Common;

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

        public async Task<PagedList<EquipmentResponse>> GetFilteredAndSortedEquipment(string? category, string? searchString, string sortBy, SortOrder sortOrder, int page, int pageSize)
        {
            var pagedEquipmentList = await equipmentRepository.GetFilteredAndSortedEquipment(category, searchString, sortBy, sortOrder, page, pageSize);

            return new PagedList<EquipmentResponse>
            {
                List = pagedEquipmentList.List.Select(e => e.ToEquipmentResponse()),
                TotalPages = pagedEquipmentList.TotalPages,
                CurrentPage = pagedEquipmentList.CurrentPage,
            };
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
