using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEquipmentService
    {
        /// <summary>
        /// Creates an <see cref="Equipment"/> from a <see cref="EquipmentRequest"/>
        /// </summary>
        /// <param name="equipmentRequest">The equipment request from the client</param>
        /// <returns>A <see cref="EquipmentResponse"/> object.</returns>
        public Task<EquipmentResponse> CreateEquipment(EquipmentRequest equipmentRequest);

        /// <summary>
        /// Returns an instance of <see cref="EquipmentResponse"/>
        /// </summary>
        /// <param name="id">The id of the <see cref="Equipment"/></param>
        /// <returns>The <see cref="EquipmentResponse"/> if found, null otherwise</returns>
        public Task<EquipmentResponse?> ReadEquipment(int id);

        /// <summary>
        /// Returns all <see cref="Equipment"/>
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<EquipmentResponse>?> ReadAllEquipment();

        /// <summary>
        /// Returns a filtered list of equipment based on category and search value.
        /// If either are null, or no matching pair found in database, return all equipment
        /// </summary>
        /// <param name="category">The category to be searched.</param>
        /// <param name="searchString">The string to be used for filtering the equipment
        /// based on category.</param>
        /// <param name="sortBy">Which category to sort by.</param>
        /// <param name="sortOrder">The sort order ASC, DESC.</param>
        /// <param name="page">The requested page to view.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A paged list of filtered and sorted equipment or all equipment if no match found.</returns>
        //public Task<PagedList<EquipmentResponse>> GetFilteredAndSortedEquipment(string? category, string? searchString, string sortBy, SortOrder sortOrder, int page, int pageSize);

        /// <summary>
        /// Sorts supplied equipment list based on sort category selected and sort order (ASC, DESC)
        /// </summary>
        /// <param name="equipment">The equipment list to be sorted.</param>
        /// <param name="sortBy">Which category to sort by.</param>
        /// <param name="sortOrder">The sort order ASC, DESC.</param>
        /// <returns>The sorted list of equipment in form of <see cref="EquipmentResponse"/>.</returns>
        //public IEnumerable<EquipmentResponse> GetSortedEquipment(IEnumerable<EquipmentResponse> equipment, string? sortBy, SortOrder sortOrder);

        /// <summary>
        /// Updates the <see cref="Equipment"/> which matches the <see cref="UpdateEquipmentRequest"/>
        /// </summary>
        /// <param name="updateEquipmentRequest">The <see cref="UpdateEquipmentRequest"/></param>
        /// <returns>The updated <see cref="Equipment"/>, migth change just to a bool.</returns>
        public Task<EquipmentResponse?> UpdateEquipment(UpdateEquipmentRequest updateEquipmentRequest);

        /// <summary>
        /// Returns true if record deleted, false otherwise
        /// </summary>
        /// <param name="id">The id of the <see cref="Equipment"/></param>
        /// <returns>boolean indicating successful deleltion</returns>
        public Task<bool> DeleteEquipment(int id);
    }
}
