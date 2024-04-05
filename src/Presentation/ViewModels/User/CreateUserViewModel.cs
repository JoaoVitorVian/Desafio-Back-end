using System.ComponentModel.DataAnnotations;

namespace ViewModels.User
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vazio")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Email não pode ser vazio")]
        [MinLength(10, ErrorMessage = "O Email deve ter pelo menos 10 caracteres.")]
        [MaxLength(180, ErrorMessage = "O Email deve ter no máximo 180 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha não pode ser vazia")]
        [MinLength(6, ErrorMessage = "A Senha deve ter pelo menos 6 caracteres.")]
        [MaxLength(180, ErrorMessage = "A Senha deve ter no máximo 180 caracteres.")]
        public string Password { get; set; }
    }
}
