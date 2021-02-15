using api.domain.Dtos.Recurso.Standard;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.domain.Dtos.Recurso
{
    public class RecursoDtoUpdate : RecursoDtoValidation
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid Id { get; set; }
    }
}
