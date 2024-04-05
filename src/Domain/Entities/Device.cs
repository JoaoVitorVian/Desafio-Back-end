namespace Domain.Entities
{
    public class Device : Base
    {
        public Device(string identifier, string description, string manufacturer, string url,long measurementId)
        {
            Identifier = identifier;
            Description = description;
            Manufacturer = manufacturer;
            Url = url;
            MeasurementId = measurementId;
            Commands = new List<Command>();
            _errors = new List<string>();

            Validate();
        }

        protected Device() { }

        public string Identifier { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Url { get; set; }
        public ICollection<Command> Commands { get; set; }
        public long? MeasurementId { get; set; }
        public Measurement Measurement { get; set; }

        public void AddCommand(Command command)
        {
            Commands.Add(command);
        }

        public override bool Validate()
        {
            // Implementar validação se necessário
            return true;
        }
    }
}