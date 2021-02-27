using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace votador.Models.Votacao
{
    public class VotoContagem
    {
        public Guid IdRecurso { get; set; }
        public string Tarefa { get; set; }
        public int Qtd { get; set; }

    }
}
