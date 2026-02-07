
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}
