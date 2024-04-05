using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Devices
{
    public class UpdateCommandViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = " O id não pode ser menor que 1.")]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UpdateParameterViewModel> Parameters { get; set; }
    }
}
