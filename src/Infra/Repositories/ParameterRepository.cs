using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ParameterRepository : BaseRepository<Parameter>, IParameterRepository
    {
        private readonly ManagerContext _context;

        public ParameterRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Parameter>> GetParametersByCommandId(long commandId)
        {
            return await _context.Parameters
                .Where(p => p.CommandId == commandId)
                .ToListAsync();
        }
    }
}
