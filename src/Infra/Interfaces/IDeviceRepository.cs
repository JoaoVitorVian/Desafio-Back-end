using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Interfaces
{
    public interface IDeviceRepository : IBaseRepository<Device>
    {
        Task<List<Device>> GetDevicesWithRainfallIntensityCapability();
        Task<List<Device>> GetAllDevices();
    }
}
