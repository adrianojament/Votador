using System.ComponentModel.DataAnnotations;

namespace api.domain.Dtos.Recurso.Standard
{
    public class RecursoDtoValidation 
    {
        [StringLength(100, ErrorMessage = "Tarefa deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Tarefa é campo obrigatório")]
        public string Tarefa { get; set; }
    }
}
