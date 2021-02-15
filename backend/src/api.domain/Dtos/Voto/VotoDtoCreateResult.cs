using api.domain.Dtos.Voto.Standard;
using System;

namespace api.domain.Dtos.Voto
{
    public class VotoDtoCreateResult : VotoDtoResult
    {
        public DateTime CriadoEm { get; set; }
    }
}
