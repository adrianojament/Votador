using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace votador.Models.Usuarios
{
    public class NovoUsuario
    {
        [Required(ErrorMessage = "A confirmação da senha é obrigatório")]
        [StringLength(20, ErrorMessage = "Deve estar entre 5 e 20 caracter", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage ="Senhas devem ser iguais")]
        public string ConfirmaSenha { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(20, ErrorMessage = "Deve estar entre 5 e 20 caracter", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O e-Mail é obrigatório")]
        [StringLength(100, ErrorMessage = "Limite de 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string eMail { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Limite de 100 caracteres")]        
        public string Nome { get; set; }
    }
}
