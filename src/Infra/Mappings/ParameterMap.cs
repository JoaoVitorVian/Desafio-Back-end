using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ParameterMap : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.ToTable("Parameter");

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

            // Relacionamento com Command (N:1)
            builder.HasOne<Command>()
                   .WithMany(c => c.Parameters)
                   .HasForeignKey(p => p.CommandId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}