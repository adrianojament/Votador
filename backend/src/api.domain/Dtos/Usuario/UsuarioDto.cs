using api.shared.Helpers;
using System;

namespace api.domain.Dtos.Usuario
{
    public class UsuarioDto
    {
        string _Senha;
        
        public Guid Id { get; set; }
        public string Senha { get => _Senha; set => _Senha = Helpers.Base64Encode(value); }
        public string eMail { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
