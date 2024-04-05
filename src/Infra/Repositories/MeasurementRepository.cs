using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class MeasurementRepository : BaseRepository<Measurement>, IMeasurementRepository
    {
        private readonly ManagerContext _context;

        public MeasurementRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Measurement> GetByParameterName(string parameterName)
        {
            return await _context.Measurements.FirstOrDefaultAsync(m => m.Name == parameterName);
        }
    }
}
