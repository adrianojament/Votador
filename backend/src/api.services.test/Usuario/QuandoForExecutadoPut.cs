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
    public class QuandoForExecutadoPut : UsuarioTestes
    {
        private IUsuariosServices _service;
        private Mock<IUsuariosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo Put.")]
        public async Task E_Possivel_Executar_Metodo_Put()
        {
            _serviceMock = new Mock<IUsuariosServices>();
            _serviceMock.Setup(m => m.Put(usuarioDtoUpdate)).ReturnsAsync(usuarioDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(usuarioDtoUpdate);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuarioAlterado, result.Nome);
            Assert.Equal(eMailUsuario, result.eMail);
            Assert.Equal(SenhaUsuarioAlterado, result.Senha);           
        }
    }
}
