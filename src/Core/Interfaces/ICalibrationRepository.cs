using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Entities;
using Core.QueryEntities;

namespace Core.Interfaces
{
    public interface ICalibrationRepository
    {
        /// <summary>
        /// Creates a <see cref="Calibration"/> object with its corresponding <see cref="Equipment"/>
        /// </summary>
        /// <param name="date">The date of the calibration.</param>
        /// <param name="price">The price of the calibration.</param>
        /// <param name="equipment">The <see cref="Equipment"/> which requires the calibration</param>
        /// <returns>The <see cref="Calibration"/></returns>
        public Task<Calibration> CreateCalibration(Calibration calibration);

        /// <summary>
        /// Returns the <see cref="Calibration"/> with the corresponding id.
        /// </summary>
        /// <param name="id">The <see cref="Calibration"/> unique identifier.</param>
        /// <returns></returns>
        public Task<Calibration?> ReadCalibration(int id);

        /// <summary>
        /// Returns a list of calibrations with their respective Equipment category and price
        /// </summary>
        /// <param name="startDate">The start date to search from.</param>
        /// <param name="endDate">The end date to search to.</param>
        /// <returns>A list of <see cref="CalibrationEquipmentCategory"/></returns>
        public Task<IReadOnlyList<CalibrationEquipmentCategory>> GetCalibrationsByEquipmentCategory(DateOnly startDate, DateOnly endDate);
    }
}
