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
    public class QuandoForExecutadoGet : RecursoTestes
    {
        private IRecursosServices _service;
        private Mock<IRecursosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo Get.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IRecursosServices>();
            _serviceMock.Setup(m => m.Get(IdRecurso)).ReturnsAsync(recursoDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdRecurso);
            Assert.NotNull(result);
            Assert.True(result.Id == IdRecurso);            
            Assert.Equal(CriadoEm, result.CriadoEm);
            Assert.Equal(AtualizadoEm, result.AtualizadoEm);
            Assert.Equal(Tarefa, result.Tarefa);

            _serviceMock = new Mock<IRecursosServices>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((RecursoDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdRecurso);
            Assert.Null(_record);
        }
    }
}
