using api.domain.Dtos.Voto;
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
    public class QuandoForExecutadoContarVotos : VotosTeste
    {
        private IVotosServices _service;
        private Mock<IVotosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo ContarVotos.")]
        public async Task E_Possivel_Executar_Metodo_ContarVotos()
        {
            _serviceMock = new Mock<IVotosServices>();
            _serviceMock.Setup(m => m.ContarVotos()).ReturnsAsync(contagemVotos.AsEnumerable());
            _service = _serviceMock.Object;

            List<VotoDtoContagem> result = (await _service.ContarVotos()).ToList();
            Assert.NotNull(result);
            Assert.True(result.Count() == contagemVotos.Count());

            for (int i = 0; i < contagemVotos.Count; i++)
            {
                Assert.Equal(result[i].IdRecurso, contagemVotos[i].IdRecurso);
                Assert.Equal(result[i].Qtd, contagemVotos[i].Qtd);
                Assert.Equal(result[i].Tarefa, contagemVotos[i].Tarefa);
            }
        }
    }
}
