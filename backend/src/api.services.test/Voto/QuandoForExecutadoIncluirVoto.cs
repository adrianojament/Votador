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
    public class QuandoForExecutadoIncluirVoto : VotosTeste
    {
        private IVotosServices _service;
        private Mock<IVotosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo IncluirVoto.")]
        public async Task E_Possivel_Executar_Metodo_IncluirVoto()
        {
            _serviceMock = new Mock<IVotosServices>();
            _serviceMock.Setup(m => m.IncluirVoto(votoCreate)).ReturnsAsync(votoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.IncluirVoto(votoCreate);
            Assert.NotNull(result);
            Assert.Equal(result.RecursoId, votoCreate.RecursoId);
            Assert.Equal(result.UsuarioId, votoCreate.UsuarioId);
            Assert.Equal(result.Comentario, votoCreate.Comentario);
        }
    }

}
