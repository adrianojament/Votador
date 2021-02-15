using System.ComponentModel.DataAnnotations;

namespace api.domain.Dtos.Usuario.Standard
{
    public class UsuarioDtoValidation
    {
        [StringLength(20, ErrorMessage = "Senha deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Senha é campo obrigatório")]
        public string Senha { get; set; }

        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "e-Mail é campo obrigatório")]
        public string eMail { get; set; }

        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        public string Nome { get; set; }
    }
}
