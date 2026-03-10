using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CalibrationsByCategory
    {
        public string EquipmentCategory { get; set; }

        public decimal TotalPaid { get; set; }

        public int NumberOfCalibrations { get; set; }

        public List<CalibrationsByCompany> ListOfCalibrationsByCompany { get; set; }
    }
}
