using api.domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.services.test.Recursos
{
    public class QuandoForExecutadoCreate : RecursoTestes
    {
        private IRecursosServices _service;
        private Mock<IRecursosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IRecursosServices>();
            _serviceMock.Setup(m => m.Post(recursoDtoCreate)).ReturnsAsync(recursoDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(recursoDtoCreate);
            Assert.NotNull(result);
            Assert.True(result.Id == IdRecurso);
            Assert.Equal(CriadoEm, result.CriadoEm);
            Assert.Equal(Tarefa, result.Tarefa);            
        }
    }
}
