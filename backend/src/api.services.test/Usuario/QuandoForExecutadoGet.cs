using api.domain.Dtos.Usuario;
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
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        private IUsuariosServices _service;
        private Mock<IUsuariosServices> _serviceMock;

        [Fact(DisplayName ="É Possivel Executar o metodo Get.")]   
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUsuariosServices>();
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(usuarioDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Nome);
            Assert.Equal(eMailUsuario, result.eMail);
            Assert.Equal(SenhaUsuario, result.Senha);

            _serviceMock = new Mock<IUsuariosServices>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UsuarioDto) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdUsuario);
            Assert.Null(_record);
        }
    }
}
