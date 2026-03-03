using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Helpers;
using Application.DTO;

namespace Application.Interfaces
{
    public interface ICalibrationService
    {
        /// <summary>
        /// Method to create a <see cref="Calibration"/> for a related <see cref="Equipment"/> with the given id.
        /// </summary>
        /// <param name="createCalibration">The <see cref="CreateCalibration(DTO.CreateCalibrationRequest)"/> DTO.</param>
        /// <returns>The result of the calibration retrieval.</returns>
        public Task<Result<CreateCalibrationResponse>> CreateCalibration(CreateCalibrationRequest createCalibration);

        /// <summary>
        /// Gets the calibration with given id.
        /// </summary>
        /// <param name="id">unique identifier.</param>
        /// <returns>The <see cref="Calibration"/></returns>
        public Task<Result<CalibrationResponse>> GetCalibration(int id);
    }
}
