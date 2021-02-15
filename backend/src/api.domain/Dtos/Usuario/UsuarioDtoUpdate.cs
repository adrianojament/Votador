using api.domain.Dtos.Usuario.Standard;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.domain.Dtos.Usuario
{
    public class UsuarioDtoUpdate : UsuarioDtoValidation
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid Id { get; set; }
    }
}
