using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
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

        public async Task<Calibration?> ReadCalibration(int id)
        {
            return await this.dbContext.Calibrations.Include(c => c.Equipment).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
