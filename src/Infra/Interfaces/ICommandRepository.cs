using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Interfaces
{
    public interface ICommandRepository : IBaseRepository<Command>
    {
        Task<List<Command>> GetCommandsByDeviceId(long deviceId);
    }
}
