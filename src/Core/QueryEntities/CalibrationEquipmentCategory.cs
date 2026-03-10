using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QueryEntities
{
    public class CalibrationEquipmentCategory
    {
        public string EquipmentCategory {  get; private set; }

        public decimal CalibrationPrice { get; private set; }

        public string CompanyName { get; private set; }

        public CalibrationEquipmentCategory(string equipmentCategory, decimal calibrationPrice, string companyName)
        {
            EquipmentCategory = equipmentCategory;
            CalibrationPrice = calibrationPrice;
            CompanyName = companyName;
        }
    }
}
