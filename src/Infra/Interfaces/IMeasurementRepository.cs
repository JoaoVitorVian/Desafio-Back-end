using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Interfaces
{
    public interface IMeasurementRepository : IBaseRepository<Measurement>
    {
        //Task<List<Measurement>> GetMeasurementsByDeviceId(long deviceId);
        Task<Measurement> GetByParameterName(string parameterName);
    }
}
