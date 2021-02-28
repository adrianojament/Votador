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
    public class QuandoForExecutadoValidateEmailPassword : UsuarioTestes
    {
        private IUsuariosServices _service;
        private Mock<IUsuariosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo ValidateEmailPassword.")]
        public async Task E_Possivel_Executar_Metodo_ValidateEmailPassword()
        {
            _serviceMock = new Mock<IUsuariosServices>();
            _serviceMock.Setup(m => m.ValidateEmailPassword(eMailUsuario, SenhaUsuario)).ReturnsAsync(validacaoPositivo);
            _service = _serviceMock.Object;

            var result = await _service.ValidateEmailPassword(eMailUsuario, SenhaUsuario);
            Assert.NotNull(result);
            Assert.True(result.Sucesso);

            _serviceMock = new Mock<IUsuariosServices>();
            _serviceMock.Setup(m => m.ValidateEmailPassword(eMailUsuario, SenhaUsuario)).ReturnsAsync(validacaoNegativo);
            _service = _serviceMock.Object;

            result = await _service.ValidateEmailPassword(eMailUsuario, SenhaUsuario);
            Assert.NotNull(result);
            Assert.False(result.Sucesso);
            Assert.NotEmpty(result.Mensagem);
        }
    }
}
