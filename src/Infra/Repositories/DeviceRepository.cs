using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        private readonly ManagerContext _context;

        public DeviceRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Device>> GetDevicesWithRainfallIntensityCapability()
        {
            return await _context.Devices
                .Include(x => x.Commands)
                .ThenInclude(x => x.Parameters)
                .Where(d => d.Manufacturer == "PredictWeather" && d.Commands.Any(c => c.Name == "get_rainfall_intensity"))
                .ToListAsync();
        }

        public async Task<List<Device>> GetAllDevices()
        {
            return await _context.Devices
                .Include(d => d.Commands)
                .ThenInclude(d => d.Parameters)
                .ToListAsync();
        }
    }
}
