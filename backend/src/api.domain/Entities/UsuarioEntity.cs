using api.domain.Entities.Standard;
using api.shared.Helpers;
using System.Collections.Generic;

namespace api.domain.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        string _Senha;

        public string Senha { get => Helpers.Base64Decode(_Senha); set => _Senha = Helpers.Base64Encode(value); }
        public string eMail { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<VotoEntity> Votos { get; set; }
    }
}
    