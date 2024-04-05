using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class DeviceMap : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Device");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Identifier)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("identifier")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(255)");

            builder.Property(x => x.Manufacturer)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("manufacturer")
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.Url)
                .HasMaxLength(255)
                .HasColumnName("url")
                .HasColumnType("VARCHAR(255)");

            // Chave estrangeira para Measurement
            builder.Property(x => x.MeasurementId)
                .HasColumnName("MeasurementId")
                .HasColumnType("BIGINT");
            builder.HasOne(x => x.Measurement)
                   .WithMany(m => m.Devices)
                   .HasForeignKey(x => x.MeasurementId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}