using api.domain.Dtos.Recurso.Standard;
using System;

namespace api.domain.Dtos.Recurso
{
    public class RecursoDtoCreateResult : RecursoDtoResult
    {
        public DateTime CriadoEm { get; set; }
    }
}
