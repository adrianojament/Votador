using api.domain.Entities.Standard;
using System;

namespace api.domain.Entities
{
    public class VotoEntity : BaseEntity
    {
        public Guid RecursoId { get; set; }
        public RecursoEntity Recurso { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; }
    }
}
