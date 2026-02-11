
using Core.Common;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {

        private ApplicationDbContext dbContext;

        public EquipmentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Equipment> CreateEquipment(Equipment equipment)
        {
            dbContext.Equipment.Add(equipment);
            await dbContext.SaveChangesAsync();
            return equipment;
        }

        public async Task<bool> DeleteEquipment(int id)
        {
            var rowsDeleted = await dbContext.Equipment.Where(e => e.Id == id).ExecuteDeleteAsync();

            return rowsDeleted != 0;
        }

        public async Task<PagedList<Equipment>> GetFilteredAndSortedEquipment(string? category, string? searchString, string sortBy, SortOrder sortOrder, int requestedPage, int pageSize)
        {
            IQueryable<Equipment> query = dbContext.Equipment;

            if (!string.IsNullOrWhiteSpace(category) && !string.IsNullOrWhiteSpace(searchString))
            {
                query = this.ApplyFiltering(query, category, searchString);
            }

            var sortingProperty = typeof(Equipment).GetProperties()
                                                   .FirstOrDefault(p => p.Name.Equals(sortBy, StringComparison.OrdinalIgnoreCase));

            if (sortingProperty == null)
                throw new ArgumentNullException($"Property {sortBy} not found in {nameof(Equipment)}");

            query = this.ApplySorting(query, sortingProperty.Name, sortOrder);


            var recordCount = await query.CountAsync();
            var equipmentList = await query.Skip((requestedPage - 1) * pageSize)
                                  .Take(pageSize).ToListAsync();

            var totalPages = Math.Ceiling((double)recordCount / pageSize);

            return new PagedList<Equipment>
            {
                List = equipmentList,
                TotalPages = (int)totalPages,
                CurrentPage = requestedPage,
            };
        }

        public async Task<IEnumerable<Equipment>> ReadAllEquipment()
        {
            return await dbContext.Equipment.ToListAsync();
        }

        public async Task<Equipment?> ReadEquipment(int id)
        {
            return await dbContext.Equipment.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Equipment?> UpdateEquipment(Equipment equipment)
        {
            var equipmentToUpdate = await ReadEquipment(equipment.Id);

            if (equipmentToUpdate != null)
            {
                dbContext.Entry(equipmentToUpdate).CurrentValues.SetValues(equipment);
            }

            var entitesChanged = await dbContext.SaveChangesAsync();

            return entitesChanged == 0 ? null : equipmentToUpdate;
        }

        private IQueryable<Equipment> ApplyFiltering(IQueryable<Equipment> query, string category, string searchString)
        {
            switch (category)
            {
                case nameof(Equipment.Id):
                    if (int.TryParse(searchString, out var id))
                        query = query.Where(e => e.Id == id);
                    break;

                case nameof(Equipment.Category):
                    query = query.Where(e => e.Category.Contains(searchString));
                    break;

                case nameof(Equipment.Type):
                    query = query.Where(e => e.Type.Contains(searchString));
                    break;

                case nameof(Equipment.Manufacturer):
                    query = query.Where(e => e.Manufacturer.Contains(searchString));
                    break;

                case nameof(Equipment.Model):
                    query = query.Where(e => e.Model.Contains(searchString));
                    break;

                case nameof(Equipment.SN):
                    query = query.Where(e => e.SN.Contains(searchString));
                    break;

                default: break;
            }

            return query;
        }

        private IQueryable<Equipment> ApplySorting(IQueryable<Equipment> query, string sortBy, SortOrder sortOrder)
        {
            switch (sortBy)
            {
                case nameof(Equipment.Id):
                    query = sortOrder == SortOrder.ASC ? query.OrderBy(e => e.Id) : query.OrderByDescending(e => e.Id);
                    break;

                case nameof(Equipment.Category):
                    query = sortOrder == SortOrder.ASC ? query.OrderBy(e => e.Category) : query.OrderByDescending(e => e.Category);
                    break;

                case nameof(Equipment.Type):
                    query = sortOrder == SortOrder.ASC ? query.OrderBy(e => e.Type) : query.OrderByDescending(e => e.Type);
                    break;

                case nameof(Equipment.Manufacturer):
                    query = sortOrder == SortOrder.ASC ? query.OrderBy(e => e.Manufacturer) : query.OrderByDescending(e => e.Manufacturer);
                    break;

                case nameof(Equipment.Model):
                    query = sortOrder == SortOrder.ASC ? query.OrderBy(e => e.Model) : query.OrderByDescending(e => e.Model);
                    break;

                case nameof(Equipment.SN):
                    query = sortOrder == SortOrder.ASC ? query.OrderBy(e => e.SN) : query.OrderByDescending(e => e.SN);
                    break;

                default: break;
            }

            return query;
        }
    }
}
