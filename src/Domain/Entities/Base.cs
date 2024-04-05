using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }

        internal List<String> _errors;
        public IReadOnlyCollection<String> Errors => _errors;

        public abstract bool Validate();
    }
}
