using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using votador.Models.Usuarios;

namespace votador.Models.Votacao
{
    public class Voto
    {
        [Required(ErrorMessage = "O campo é obrigatório")]
        public Guid IdRecurso { get; set; }

        [Required(ErrorMessage = "O comentário é obrigatório")]
        [StringLength(200, ErrorMessage = "Limite de 200 caracteres")]        
        public string Comentario { get; set; }

        [Required(ErrorMessage = "O e-Mail é obrigatório")]
        [StringLength(100, ErrorMessage = "Limite de 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string eMail { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(20, ErrorMessage = "Deve estar entre 5 e 20 caracter", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
