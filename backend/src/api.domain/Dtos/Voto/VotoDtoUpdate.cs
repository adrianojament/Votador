using api.domain.Dtos.Voto.Standard;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.domain.Dtos.Voto
{
    public class VotoDtoUpdate : VotoDtoValidation
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid Id { get; set; }
    }
}
