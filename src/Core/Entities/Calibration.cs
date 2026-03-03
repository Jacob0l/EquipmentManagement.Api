using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Calibration
    {
        /// <summary>
        /// The calibration Id which is unique for all calibrations.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The date of the calibration.
        /// </summary>
        public DateOnly Date { get; private set; }


        /// <summary>
        /// The cost of the calibration
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// The company which is performing the calibration.
        /// </summary>
        public string CompanyName { get; private set; }

        /// <summary>
        /// Foreign key 
        /// </summary>
        public int EquipmentId { get; private set; }

        /// <summary>
        /// The <see cref="Equipment"/> for the <see cref="Calibration"/>.
        /// </summary>
        public Equipment Equipment { get; private set; } = null!;

        private Calibration() { }

        public Calibration(DateOnly date, string companyName, decimal price, Equipment equipment)
        {
            Date = date;
            CompanyName = companyName;
            Price = price;
            Equipment = equipment;
        }

        [JsonConstructor]
        public Calibration(DateOnly date, string companyName, decimal price)
        {
            Date = date;
            CompanyName = companyName;
            Price = price;
        }

        public void DateChange(DateOnly newDate) => Date = newDate;

        public void CompanyNameChange(string companyName) => CompanyName = companyName;

        public void PriceChange(decimal price) => Price = price;

        public void EquipmentChange(Equipment equipment)
        {
            EquipmentId = equipment.Id;
            Equipment = equipment;
        }
    }
}
