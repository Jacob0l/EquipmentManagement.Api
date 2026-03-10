using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.QueryEntities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CalibrationRepository : ICalibrationRepository
    {

        private ApplicationDbContext dbContext;

        public CalibrationRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Calibration> CreateCalibration(Calibration calibration)
        {
            this.dbContext.Calibrations.Add(calibration);
            await this.dbContext.SaveChangesAsync();
            return calibration;
        }

        public async Task<IReadOnlyList<CalibrationEquipmentCategory>> GetCalibrationsByEquipmentCategory(DateOnly startDate, DateOnly endDate)
        {
            return await this.dbContext.Calibrations
                        .Where(c => c.Date >= startDate && c.Date <= endDate)
                        .Select(c => new CalibrationEquipmentCategory( c.Equipment.Category, c.Price, c.CompanyName))
                        .ToListAsync();
        }

        public async Task<Calibration?> ReadCalibration(int id)
        {
            return await this.dbContext.Calibrations.Include(c => c.Equipment).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
