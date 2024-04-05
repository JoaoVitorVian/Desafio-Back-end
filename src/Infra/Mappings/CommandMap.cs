using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class CommandMap : IEntityTypeConfiguration<Command>
    {
        public void Configure(EntityTypeBuilder<Command> builder)
        {
            builder.ToTable("Command");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(255)");

            // Relacionamento com Device (N:1)
            builder.HasOne<Device>()
                   .WithMany(d => d.Commands)
                   .HasForeignKey(c => c.DeviceId) 
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}