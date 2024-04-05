using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ParameterDTO
    {
        public ParameterDTO(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public ParameterDTO()
        { }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
