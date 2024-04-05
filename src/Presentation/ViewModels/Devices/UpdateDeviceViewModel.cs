using Presentation.ViewModels.Devices;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Devices
{
    public class UpdateDeviceViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = " O id não pode ser menor que 1.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Identificador não pode ser nulo.")]
        public string Identifier { get; set; }

        [Required(ErrorMessage = "É necessário ter uma descrição.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fabricante não pode ser nulo.")]
        public string Manufacturer { get; set; }

        public string Url { get; set; }

        public List<UpdateCommandViewModel> Commands { get; set; }
    }
}