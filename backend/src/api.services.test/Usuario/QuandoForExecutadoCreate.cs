using api.domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.services.test.Usuario
{
    public class QuandoForExecutadoCreate : UsuarioTestes
    {
        private IUsuariosServices _service;
        private Mock<IUsuariosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IUsuariosServices>();
            _serviceMock.Setup(m => m.Post(usuarioDtoCreate)).ReturnsAsync(usuarioDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(usuarioDtoCreate);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Nome);
            Assert.Equal(eMailUsuario, result.eMail);
            Assert.Equal(SenhaUsuario, result.Senha);           
        }
    }
}
