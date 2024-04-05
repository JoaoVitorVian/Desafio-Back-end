using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class DeviceDTO
    {
        public DeviceDTO(long id, string identifier, string description, string manufacturer, string url, List<CommandDTO> commands, long measurementId)
        {
            Id = id;
            Identifier = identifier;
            Description = description;
            Manufacturer = manufacturer;
            Url = url;
            Commands = commands;
            MeasurementId = measurementId;
        }

        public DeviceDTO()
        { }

        public long Id { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Url { get; set; }
        public long? MeasurementId { get; set; }
        public MeasurementDTO Measurement { get; set; }
        public List<CommandDTO> Commands { get; set; }
    }
}
