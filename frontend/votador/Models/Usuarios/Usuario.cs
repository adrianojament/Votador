using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace votador.Models.Usuarios
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Senha { get; set; }
        public string eMail { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime atualizadoEm { get; set; }
    }
}
