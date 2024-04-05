using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDeviceService
    {
        Task<DeviceDTO> Create(DeviceDTO deviceDTO);
        Task<DeviceDTO> Update(DeviceDTO deviceDTO);
        Task Delete(long id);
        Task<DeviceDTO> Get(long id);
        Task<List<DeviceDTO>> GetAll();
        Task<List<DeviceDTO>> GetDevicesWithRainfallIntensity();
    }
}