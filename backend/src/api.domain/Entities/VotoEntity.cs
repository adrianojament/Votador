using api.domain.Entities.Standard;
using System;

namespace api.domain.Entities
{
    public class VotoEntity : BaseEntity
    {
        public Guid RecursoId { get; set; }
        public virtual RecursoEntity Recurso { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }
        public string Comentario { get; set; }
    }
}
