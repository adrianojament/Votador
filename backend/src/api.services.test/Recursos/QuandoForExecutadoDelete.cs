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
    public class QuandoForExecutadoDelete : RecursoTestes
    {
        private IRecursosServices _service;
        private Mock<IRecursosServices> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o metodo Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IRecursosServices>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdRecurso);
            Assert.True(deletado);

            _serviceMock = new Mock<IRecursosServices>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;
            deletado = await _service.Delete(IdRecurso);
            Assert.False(deletado);
        }
    }
}
