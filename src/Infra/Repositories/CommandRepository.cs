using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class CommandRepository : BaseRepository<Command>, ICommandRepository
    {
        private readonly ManagerContext _context;

        public CommandRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Command>> GetCommandsByDeviceId(long deviceId)
        {
            return await _context.Commands
                .Where(c => c.DeviceId == deviceId)
                .ToListAsync();
        }
    }
}
