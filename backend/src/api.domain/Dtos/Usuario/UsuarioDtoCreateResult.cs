using api.domain.Dtos.Usuario.Standard;
using System;

namespace api.domain.Dtos.Usuario
{
    public class UsuarioDtoCreateResult : UsuarioDtoResult
    {
        public DateTime CriadoEm { get; set; }
    }
}
