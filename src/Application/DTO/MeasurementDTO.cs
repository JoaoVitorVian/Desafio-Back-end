using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class MeasurementDTO
    {
        public MeasurementDTO(long id, DateTime dateTime, string name, decimal value)
        {
            Id = id;
            DateTime = dateTime;
            Name = name;
            Value = value;
        }

        public MeasurementDTO()
        { }

        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}