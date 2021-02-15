using api.domain.Dtos.Recurso;
using api.domain.Dtos.Usuario;
using System;

namespace api.domain.Dtos.Voto.Standard
{
    public class VotoDtoResult
    {
        public Guid Id { get; set; }
        public Guid RecursoId { get; set; }
        public RecursoDto Recurso { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string Comentario { get; set; }
    }
}
