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
    public class QuandoForExecutadoValidationEmailsAlreadyExist : UsuarioTestes
    {
        private IUsuariosServices _service;
        private Mock<IUsuariosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo ValidationEmailsAlreadyExist.")]
        public async Task E_Possivel_Executar_Metodo_ValidationEmailsAlreadyExist()
        {
            _serviceMock = new Mock<IUsuariosServices>();
            _serviceMock.Setup(m => m.ValidationEmailsAlreadyExist(eMailUsuario, It.IsAny<Guid>())).ReturnsAsync(validacaoPositivo);
            _service = _serviceMock.Object;

            var result = await _service.ValidationEmailsAlreadyExist(eMailUsuario, IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Sucesso);

            _serviceMock = new Mock<IUsuariosServices>();
            _serviceMock.Setup(m => m.ValidationEmailsAlreadyExist(eMailUsuario, It.IsAny<Guid>())).ReturnsAsync(validacaoNegativo);
            _service = _serviceMock.Object;

            result = await _service.ValidationEmailsAlreadyExist(eMailUsuario, Guid.NewGuid());
            Assert.NotNull(result);
            Assert.False(result.Sucesso);
            Assert.NotEmpty(result.Mensagem);


        }
    }
}
