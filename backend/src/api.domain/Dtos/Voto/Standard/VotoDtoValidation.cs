using System;
using System.ComponentModel.DataAnnotations;

namespace api.domain.Dtos.Voto.Standard
{
    public class VotoDtoValidation
    {
        [Required(ErrorMessage = "Id do Recurso é campo obrigatório")]
        public Guid RecursoId { get; set; }

        [Required(ErrorMessage = "Id do Usuario é campo obrigatório")]
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Comentário é campo obrigatório")]
        [StringLength(200, ErrorMessage = "Comentário deve ter no máximo {1} caracteres.")]
        public string Comentario { get; set; }
    }
}
