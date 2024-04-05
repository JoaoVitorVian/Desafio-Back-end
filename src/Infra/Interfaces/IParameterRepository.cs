using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Interfaces
{
    public interface IParameterRepository : IBaseRepository<Parameter>
    {
        Task<List<Parameter>> GetParametersByCommandId(long commandId);
    }
}
