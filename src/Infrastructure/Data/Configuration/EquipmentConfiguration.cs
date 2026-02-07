using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configuration
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Manufacturer)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.SN)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
