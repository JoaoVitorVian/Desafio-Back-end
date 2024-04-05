namespace Domain.Entities
{
    public class Measurement : Base
    {
        public Measurement(DateTime dateTime, decimal value, string name)
        {
            DateTime = dateTime;
            Value = value;
            Name = name;
        }

        public Measurement() { }

        public DateTime DateTime { get;  set; }
        public string Name { get; set; }
        public decimal Value { get;  set; }
        public ICollection<Device> Devices { get; set; } = new List<Device>();

        public override bool Validate()
        {
            // Implementar validação se necessário
            return true;
        }
    }
}
