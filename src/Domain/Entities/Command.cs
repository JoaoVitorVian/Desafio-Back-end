using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Command : Base
    {
        public Command(string name, string description, long deviceId)
        {
            Name = name;
            Description = description;
            DeviceId = deviceId;
            Parameters = new List<Parameter>();
        }

        protected Command() { }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public long DeviceId { get; private set; }
        public ICollection<Parameter> Parameters { get; private set; }

        public void AddParameter(Parameter parameter)
        {
            Parameters.Add(parameter);
        }

        public override bool Validate()
        {
            // Implementar validação se necessário
            return true;
        }
    }
}
