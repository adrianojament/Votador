using System;

namespace api.domain.Dtos.Usuario
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Senha { get; set; }
        public string eMail { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
