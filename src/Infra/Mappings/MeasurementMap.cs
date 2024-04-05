using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class MeasurementMap : IEntityTypeConfiguration<Measurement>
    {
        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
            builder.ToTable("Measurement");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.DateTime)
                .IsRequired()
                .HasColumnName("dateTime")
                .HasColumnType("DATETIME2");

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnName("value")
                .HasColumnType("DECIMAL(18,2)");
        }
    }
}