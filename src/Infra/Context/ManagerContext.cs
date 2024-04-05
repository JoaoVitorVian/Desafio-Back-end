using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext() { }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Command> Commands { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new DeviceMap());
            modelBuilder.ApplyConfiguration(new CommandMap());
            modelBuilder.ApplyConfiguration(new MeasurementMap());
            modelBuilder.ApplyConfiguration(new ParameterMap());

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var measurements = new List<Measurement>
            {
                new Measurement { Id = 1, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 10, Name = "São Paulo" },
                new Measurement { Id = 2, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 15, Name = "Rio de Janeiro" },
                new Measurement { Id = 3, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 12, Name = "Brasília" },
                new Measurement { Id = 4, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 18, Name = "Salvador" },
                new Measurement { Id = 5, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 9, Name = "Fortaleza" },
                new Measurement { Id = 6, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 20, Name = "Curitiba" },
                new Measurement { Id = 7, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 16, Name = "Recife" },
                new Measurement { Id = 8, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 13, Name = "Manaus" },
                new Measurement { Id = 9, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 11, Name = "Porto Alegre" },
                new Measurement { Id = 10, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 14, Name = "Belém" },
                new Measurement { Id = 11, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 17, Name = "Goiânia" },
                new Measurement { Id = 12, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 19, Name = "Florianópolis" },
                new Measurement { Id = 13, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 8, Name = "Vitória" },
                new Measurement { Id = 14, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 21, Name = "Natal" },
                new Measurement { Id = 15, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 22, Name = "João Pessoa" },
                new Measurement { Id = 16, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 23, Name = "Campo Grande" },
                new Measurement { Id = 17, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 24, Name = "Teresina" },
                new Measurement { Id = 18, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 25, Name = "Cuiabá" },
                new Measurement { Id = 19, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 26, Name = "São Luís" },
                new Measurement { Id = 20, DateTime = new DateTime(2024, 4, 4, 18, 29, 20, DateTimeKind.Utc), Value = 27, Name = "Maceió" }
            };

            modelBuilder.Entity<Measurement>().HasData(measurements);
        }

    }
}
