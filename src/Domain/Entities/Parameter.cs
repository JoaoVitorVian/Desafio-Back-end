using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
      public class Parameter : Base
      {
            public Parameter(string name, string description, long commandId)
            {
                Name = name;
                Description = description;
                CommandId = commandId;
            }

            protected Parameter() { }

            public string Name { get; private set; }
            public string Description { get; private set; }
            public long CommandId { get; private set; }

            public override bool Validate()
            {
                // Implementar validação se necessário
                return true;
            }
      }
}
