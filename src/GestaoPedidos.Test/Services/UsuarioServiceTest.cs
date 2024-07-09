using Moq;
using Xunit;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Application.Services;
using GestaoPedidos.Domain.Interfaces.Repositories;

namespace GestaoPedidos.Tests
{
    public class UsuarioServiceTest
    {
        private readonly Mock<IUsuarioRepository> _mockRepository;
        private readonly UsuarioService _service;

        public UsuarioServiceTest()
        {
            _mockRepository = new Mock<IUsuarioRepository>();
            _service = new UsuarioService(_mockRepository.Object);
        }

        [Fact]
        public async Task CadastrarUsuario_CallsInsertMethod_WithCorrectParameters()
        {
            // Arrange
            var usuario = new Usuario(1, "Henrique", "henrique@gmail.com", "1234", 1, true);
            _mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<Usuario>())).Returns(Task.CompletedTask);

            // Act
            await _service.CadastrarUsuario(usuario);

            // Assert
            _mockRepository.Verify(repo => repo.Cadastrar(usuario), Times.Once);
        }

        [Fact]
        public async Task AtualizarUsuario_CallsUpdateMethod_WithCorrectParameters()
        {
            // Arrange
            var usuario = new Usuario(1, "Henrique", "henrique@gmail.com", "1234", 1, true);
            _mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<Usuario>())).Returns(Task.CompletedTask);

            // Act
            await _service.AtualizarUsuario(usuario);

            // Assert
            _mockRepository.Verify(repo => repo.Atualizar(usuario), Times.Once);
        }

        [Fact]
        public async Task ObterUsuario_ReturnsExpectedPagamento()
        {
            // Arrange
            var usuarioId = 1;
            var usuario = new Usuario(1, "Henrique", "henrique@gmail.com", "1234", 1, true);
            _mockRepository.Setup(repo => repo.Obter(usuarioId)).ReturnsAsync(usuario);

            // Act
            var result = await _service.ObterUsuario(usuarioId);

            // Assert
            Assert.Equal(usuario, result);
            _mockRepository.Verify(repo => repo.Obter(usuarioId), Times.Once);
        }

        [Fact]
        public async Task ObterUsuarios_ReturnsExpectedPagamentos()
        {
            // Arrange
            var usuarios = new List<Usuario>
            {
                new Usuario(1, "Henrique", "henrique@gmail.com", "1234", 1, true),
                new Usuario(2, "Yan", "yan@gmail.com", "5678", 1, true),
                new Usuario(3, "Artur", "artur@gmail.com", "4321", 1, true)
            }.AsQueryable();

            _mockRepository.Setup(repo => repo.Obter()).ReturnsAsync(usuarios);

            // Act
            var result = await _service.ObterUsuarios();

            // Assert
            Assert.Equal(usuarios, result);
            _mockRepository.Verify(repo => repo.Obter(), Times.Once);
        }

        [Fact]
        public async Task RemoverUsuario_CallsDeleteMethod_WithCorrectParameters()
        {
            // Arrange
            var usuarioId = 1;
            _mockRepository.Setup(repo => repo.Remover(usuarioId)).Returns(Task.CompletedTask);

            // Act
            await _service.RemoverUsuario(usuarioId);

            // Assert
            _mockRepository.Verify(repo => repo.Remover(usuarioId), Times.Once);
        }
    }
}