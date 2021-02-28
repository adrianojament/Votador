using api.domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.services.test.Voto
{
    public class QuandoForExecutadoValidacaoEInserir : VotosTeste
    {
        private IVotosServices _service;
        private Mock<IVotosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo ValidacaoEInserir.")]
        public async Task E_Possivel_Executar_Metodo_ValidacaoEInserir()
        {
            _serviceMock = new Mock<IVotosServices>();
            _serviceMock.Setup(m => m.ValidacaoEInserir(votoRecepcao)).ReturnsAsync(validacaoPositivo);
            _service = _serviceMock.Object;

            var result = await _service.ValidacaoEInserir(votoRecepcao);
            Assert.NotNull(result);
            Assert.True(result.Sucesso);

            _serviceMock = new Mock<IVotosServices>();
            _serviceMock.Setup(m => m.ValidacaoEInserir(votoRecepcao)).ReturnsAsync(validacaoNegativo);
            _service = _serviceMock.Object;

            result = await _service.ValidacaoEInserir(votoRecepcao);
            Assert.NotNull(result);
            Assert.NotEmpty(result.Mensagem);
            Assert.False(result.Sucesso);

        }
    }
}
