using System;

namespace api.domain.Dtos.Usuario.Standard
{
    public class UsuarioDtoResult
    {
        public Guid Id { get; set; }
        public string Senha { get; set; }
        public string eMail { get; set; }
        public string Nome { get; set; }
    }
}
