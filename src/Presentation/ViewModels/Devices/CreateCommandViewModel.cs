namespace Presentation.ViewModels.Devices
{
    public class CreateCommandViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CreateParameterViewModel> Parameters { get; set; }
    }
}
