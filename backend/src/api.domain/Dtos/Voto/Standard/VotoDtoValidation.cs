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
    }
}
