using api.shared.Helpers;
using System;

namespace api.domain.Dtos.Usuario
{
    public class UsuarioDtoVoto
    {
                
        public Guid Id { get; set; }        
        public string eMail { get; set; }
        public string Nome { get; set; }
        
    }
}
