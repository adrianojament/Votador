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
    public class QuandoForExecutadoPut : RecursoTestes
    {
        private IRecursosServices _service;
        private Mock<IRecursosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo Put.")]
        public async Task E_Possivel_Executar_Metodo_Put()
        {
            _serviceMock = new Mock<IRecursosServices>();
            _serviceMock.Setup(m => m.Put(recursoDtoUpdate)).ReturnsAsync(recursoDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(recursoDtoUpdate);
            Assert.NotNull(result);
            Assert.True(result.Id == IdRecurso);
            Assert.Equal(TarefaAlterado, result.Tarefa);            
        }
    }
}
