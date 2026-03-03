using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CalibrationConfiguration : IEntityTypeConfiguration<Calibration>
    {
        public void Configure(EntityTypeBuilder<Calibration> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Date)
                .IsRequired();

            builder.Property(c => c.CompanyName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Price)
                .HasPrecision(18,2)
                .IsRequired();

            builder
                .HasOne(c => c.Equipment)
                .WithMany(c => c.Calibrations)
                .HasForeignKey(c => c.EquipmentId)
                .IsRequired();

        }
    }
}
