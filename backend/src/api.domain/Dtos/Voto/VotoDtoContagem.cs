using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.domain.Dtos.Voto
{
    public class VotoDtoContagem
    {
        public Guid Id { get; set; }
        public string Tarefa { get; set; }
        public int Qtd { get; set; }
    }
}
