using System;

namespace api.domain.Dtos.Recurso
{
    public class RecursoDto
    {
        public Guid Id { get; set; }
        public string Tarefa { get; set; }        
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
