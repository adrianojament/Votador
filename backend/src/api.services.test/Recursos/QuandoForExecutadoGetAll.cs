using api.domain.Dtos.Recurso;
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
    public class QuandoForExecutadoGetAll : RecursoTestes
    {
        private IRecursosServices _service;
        private Mock<IRecursosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo GetAll.")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IRecursosServices>();
            _serviceMock.Setup(m => m.Get()).ReturnsAsync(listRecursosDto);
            _service = _serviceMock.Object;

            var result = await _service.Get();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);


            var listResult = new List<RecursoDto>();
            _serviceMock = new Mock<IRecursosServices>();
            _serviceMock.Setup(m => m.Get()).ReturnsAsync(listResult.AsEnumerable());
            _service = _serviceMock.Object;

            var resultEmpty = await _service.Get();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}
