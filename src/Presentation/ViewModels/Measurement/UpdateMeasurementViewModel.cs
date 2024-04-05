namespace Presentation.ViewModels.Measurement
{
    public class UpdateMeasurementViewModel
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
