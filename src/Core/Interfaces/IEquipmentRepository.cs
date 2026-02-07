using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEquipmentRepository
    {
        /// <summary>
        /// Create a new instance of <see cref="Equipment"/>
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns>The created instance of the <see cref="Equipment"/></returns>
        public Task<Equipment> CreateEquipment(Equipment equipment);

        /// <summary>
        /// Returns an instance of <see cref="Equipment"/>
        /// </summary>
        /// <param name="id">The id of the <see cref="Equipment"/></param>
        /// <returns>The <see cref="Equipment"/> if found, null otherwise</returns>
        public Task<Equipment?> ReadEquipment(int id);

        /// <summary>
        /// Returns all <see cref="Equipment"/>.
        /// </summary>
        /// <returns>An enumerable of <see cref="Equipment"/></returns>
        public Task<IEnumerable<Equipment>> ReadAllEquipment();

        /// <summary>
        /// Returns a filtered list of equipment based on category and search value.
        /// If either are null, or no matching pair found in database, return all equipment
        /// </summary>
        /// <param name="category">The category to be searched.</param>
        /// <param name="searchString">The string to be used for filtering the equipment
        /// based on category.</param>
        /// <returns>A list of filtered equipment or all equipment if no match found.</returns>
        //public Task<IEnumerable<Equipment>> GetFilteredEquipment(string? category, string? searchString);

        /// <summary>
        /// Returns filtered, sorted and paginated
        /// </summary>
        /// <param name="category">The category to be searched.</param>
        /// <param name="searchString">The string to be used for filtering the equipment
        /// based on category.</param>
        /// <param name="sortBy">The category sorted by.</param>
        /// <param name="sortOrder">The chosen sort order.</param>
        /// <param name="requestedPage">The page requested to be shown.</param>
        /// <param name="pageSize">The page size to be shown.</param>
        /// <returns>A paged list of equipment which is filtered, sorted and paginated.</returns>
        //public Task<PagedList<Equipment>> GetFilteredAndSortedEquipment(
        //    string? category,
        //    string? searchString,
        //    string sortBy,
        //    SortOrder sortOrder,
        //    int requestedPage,
        //    int pageSize);

        /// <summary>
        /// Update the <see cref="Equipment"/>
        /// </summary>
        /// <param name="equipment">The <see cref="Equipment"/> to update</param>
        /// <returns>The updated <see cref="Equipment"/></returns>
        public Task<Equipment?> UpdateEquipment(Equipment equipment);

        /// <summary>
        /// Delete the <see cref="Equipment"/>
        /// </summary>
        /// <param name="id">The id of the <see cref="Equipment"/></param>
        /// <returns></returns>
        public Task<bool> DeleteEquipment(int id);
    }
}
