using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace votador.Models.Recursos
{
    public class NovoRecurso
    {
        [MaxLength(100,ErrorMessage ="Tamanho Maximo de 100")]
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Tarefa { get; set; }
    }
}
