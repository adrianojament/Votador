using api.shared.Helpers;
using System;

namespace api.domain.Dtos.Usuario.Standard
{
    public class UsuarioDtoResult
    {
        string _Senha;
        public Guid Id { get; set; }
        public string Senha { get => Helpers.Base64Decode(_Senha); set => _Senha = Helpers.Base64Encode(value); }
        public string eMail { get; set; }
        public string Nome { get; set; }
    }
}
