
using Application.DTO;
using Application.Helpers;
using Application.Interfaces;
using Core.Common;
using Core.Entities;
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

        public async Task<Result<PagedList<EquipmentResponse>>> GetFilteredAndSortedEquipment(string? category, string? searchString, string sortBy, SortOrder sortOrder, int page, int pageSize)
        {
            //Here we should check the category if it matches an equipement category and then get the category and pass it on and the same with the soryBy. The code is in repo right now.

            var matchingProperty = typeof(Equipment).GetProperties().FirstOrDefault(p => p.Name.Equals(category, StringComparison.OrdinalIgnoreCase));

            if (matchingProperty == null)
                return Result<PagedList<EquipmentResponse>>.Failure($"The category {category} does not match any properties in {nameof(Equipment)}");
                

            var pagedEquipmentList = await equipmentRepository.GetFilteredAndSortedEquipment(category, searchString, sortBy, sortOrder, page, pageSize);

            var result = new PagedList<EquipmentResponse>
            {
                List = pagedEquipmentList.List.Select(e => e.ToEquipmentResponse()),
                TotalPages = pagedEquipmentList.TotalPages,
                CurrentPage = pagedEquipmentList.CurrentPage,
            };

            return Result<PagedList<EquipmentResponse>>.Success(result);
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
