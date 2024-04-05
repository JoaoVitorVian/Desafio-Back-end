using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CommandDTO
    {
        public CommandDTO(long id, string name, string description, List<ParameterDTO> parameters)
        {
            Id = id;
            Name = name;
            Description = description;
            Parameters = parameters;
        }
        public CommandDTO()
        { }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ParameterDTO> Parameters { get; set; }
    }
}
