using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace votador.Models.Recursos
{
    public class Recurso
    {
        public Guid Id { get; set; }
        public string Tarefa { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
