using api.domain.Dtos.Usuario.Standard;
using System;

namespace api.domain.Dtos.Usuario
{
    public class UsuarioDtoUpdateResult : UsuarioDtoResult
    {
        public DateTime AtualizadoEm { get; set; }
    }
}
