using Application.DTO;
using Presentation.ViewModels.Devices;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Login
{
    public class CreateDeviceViewModel
    {

        [Required(ErrorMessage = "Identificador não pode ser nulo.")]
        public string Identifier { get; set; }

        [Required(ErrorMessage = "É necessário ter uma descrição.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fabricante não pode ser nulo.")]
        public string Manufacturer { get; set; }

        public string Url { get; set; }

        public List<CreateCommandViewModel> Commands { get; set; }
    }
}