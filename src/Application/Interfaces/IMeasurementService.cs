using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMeasurementService
    {
        Task<MeasurementDTO> Create(MeasurementDTO measurement);
        Task<MeasurementDTO> Update(MeasurementDTO measurement);
        Task<MeasurementDTO> Get(long id);
        Task<List<MeasurementDTO>> GetAll();
    }
}