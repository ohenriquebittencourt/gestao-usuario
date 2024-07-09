using Xunit;
using Moq;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Application.Services;
using GestaoPedidos.Domain.Interfaces.Repositories;

namespace GestaoPedidos.Tests
{
    public class ClienteServiceTest
    {
        private readonly Mock<IClienteRepository> _mockRepository;
        private readonly ClienteService _service;

        public ClienteServiceTest()
        {
            _mockRepository = new Mock<IClienteRepository>();
            _service = new ClienteService(_mockRepository.Object);
        }

        [Fact]
        public async Task CadastrarCliente_CallsInsertMethod_WithCorrectParameters()
        {
            // Arrange
            var cliente = new Cliente("Henrique", "444444444-44");
            _mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            // Act
            await _service.CadastrarCliente(cliente);

            // Assert
            _mockRepository.Verify(repo => repo.Cadastrar(cliente), Times.Once);
        }

        [Fact]
        public async Task AtualizarCliente_CallsUpdateMethod_WithCorrectParameters()
        {
            // Arrange
            var cliente = new Cliente("Henrique", "444444444-44");
            _mockRepository.Setup(repo => repo.Atualizar(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            // Act
            await _service.AtualizarCliente(cliente);

            // Assert
            _mockRepository.Verify(repo => repo.Atualizar(cliente), Times.Once);
        }

        [Fact]
        public async Task ObterCliente_ReturnsExpectedCategoriaProduto()
        {
            // Arrange
            var cpf = "444444444-44";
            var cliente = new Cliente("Henrique", "444444444-44");
            _mockRepository.Setup(repo => repo.ObterPorCpf(cpf)).ReturnsAsync(cliente);

            // Act
            var result = await _service.ObterCliente(cpf);

            // Assert
            Assert.Equal(cliente, result);
            _mockRepository.Verify(repo => repo.ObterPorCpf(cpf), Times.Once);
        }

        [Fact]
        public async Task RemoverCliente_CallsDeleteMethod_WithCorrectParameters()
        {
            // Arrange
            var clienteId = 1;
            _mockRepository.Setup(repo => repo.Remover(clienteId)).Returns(Task.CompletedTask);

            // Act
            await _service.DeletarCliente(clienteId);

            // Assert
            _mockRepository.Verify(repo => repo.Remover(clienteId), Times.Once);
        }
    }
}