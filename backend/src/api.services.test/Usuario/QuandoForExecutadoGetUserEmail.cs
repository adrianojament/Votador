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
    public class QuandoForExecutadoGetUserEmail : UsuarioTestes
    {
        private IUsuariosServices _service;
        private Mock<IUsuariosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo GetUserEmail.")]
        public async Task E_Possivel_Executar_Metodo_GetUserEmail()
        {
            _serviceMock = new Mock<IUsuariosServices>();
            _serviceMock.Setup(m => m.GetUserEmail(eMailUsuario)).ReturnsAsync(usuarioDto);
            _service = _serviceMock.Object;

            var result = await _service.GetUserEmail(eMailUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Nome);
            Assert.Equal(eMailUsuario, result.eMail);
            Assert.Equal(SenhaUsuario, result.Senha);
            
        }
    }
}
