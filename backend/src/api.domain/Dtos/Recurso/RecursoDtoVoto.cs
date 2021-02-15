using System;

namespace api.domain.Dtos.Recurso
{
    public class RecursoDtoVoto
    {
        public Guid Id { get; set; }
        public string Tarefa { get; set; }        
        public DateTime CriadoEm { get; set; }
        
    }
}
