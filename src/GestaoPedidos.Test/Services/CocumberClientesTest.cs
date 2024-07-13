using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Application.Services;
using GestaoPedidos.Domain.Entities;
using Xunit.Gherkin.Quick;
using Xunit;
using Moq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedidos.Test.Services
{
    [FeatureFile("Services/cliente.feature")]
    public sealed class CocumberClientesTest : Feature
    {
        private readonly Mock<IClienteRepository> _mockRepository;
        private readonly ClienteService _mockService;
        private Cliente _cliente;
        private int _clienteId;

        public CocumberClientesTest()
        {
            _mockRepository = new Mock<IClienteRepository>();
            _mockService = new ClienteService(_mockRepository.Object);
        }

        #region OBTER

        [Given(@"acessar a rota de busca")]
        public void Acessar_rota_de_busca_cliente_com_cpf()
        {
            var url = $"https://seusite.com/api/cliente";
        }

        [When(@"eu efetuar a requisicao com cpf")]
        public async Task efetuar_requisica_obter()
        {
            var cpf = "444444444-44";
            var cliente = new Cliente("Henrique", "444444444-44", "henrique@gmail.com", "27258939", DateTime.Now);
            _mockRepository.Setup(repo => repo.ObterPorCpf(cpf)).ReturnsAsync(cliente);
            _cliente = await _mockService.ObterCliente(cpf);
        }

        [Then(@"obter os clientes com sucesso")]
        public void obter_um_cliente_com_sucesso()
        {
            Assert.Equal(_cliente.CPF, "444444444-44");
        }

        #endregion

        #region CADASTRAR

        [Given(@"acessar a rota de cadastro")]
        public void acessar_rota_de_cadastro()
        {
            var url = $"https://seusite.com/api/cliente";
        }

        [And(@"eu tenho os dados do cliente")]
        public void tenho_dados_do_cliente_cadastro()
        {
            _cliente = new Cliente("Henrique", "444444444-44", "henrique@gmail.com", "27258939", DateTime.Now);
        }

        [When(@"eu enviar a requisicao")]
        public async Task efetuar_requisicao_cadastro()
        {
            _mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<Cliente>())).Returns(Task.CompletedTask);
            await _mockService.CadastrarCliente(_cliente);
        }

        [Then(@"cadastrar um cliente com sucesso")]
        public void cadastrar_um_cliente_com_sucesso()
        {
            _mockRepository.Verify(repo => repo.Cadastrar(_cliente), Times.Once);
        }

        #endregion

        #region ATUALIZAR

        [Given(@"acessar a rota de atualizacao")]
        public void acessar_rota_de_atualizacao()
        {
            var url = $"https://seusite.com/api/cliente";
        }

        [And(@"eu tenho os dados do cliente atualizado")]
        public void tenho_dados_do_cliente_atualizacao()
        {
            _cliente = new Cliente("Henrique", "444444444-44", "henrique@gmail.com", "27258939", DateTime.Now);
        }

        [When(@"eu enviar a requisicao de atualizacao")]
        public async Task efetuar_requisicao_atualizacao()
        {
            _mockRepository.Setup(repo => repo.Atualizar(It.IsAny<Cliente>())).Returns(Task.CompletedTask);
            await _mockService.AtualizarCliente(_cliente);
        }

        [Then(@"atualizar um cliente com sucesso")]
        public void atualizar_um_cliente_com_sucesso()
        {
            _mockRepository.Verify(repo => repo.Atualizar(_cliente), Times.Once);
        }

        #endregion

        #region DELETAR

        [Given(@"acessar a rota de delete")]
        public void acessar_rota_de_delete()
        {
            var url = $"https://seusite.com/api/cliente";
        }

        [And(@"eu tenho o id do cliente")]
        public void tenho_id_do_cliente_delete()
        {
            _clienteId = 1;
        }

        [When(@"eu enviar a requisicao de delete")]
        public async Task efetuar_requisicao_delete()
        {
            _mockRepository.Setup(repo => repo.Remover(_clienteId)).Returns(Task.CompletedTask);
            await _mockService.DeletarCliente(_clienteId);
        }

        [Then(@"deletar um cliente com sucesso")]
        public void delete_um_cliente_com_sucesso()
        {
            _mockRepository.Verify(repo => repo.Remover(_clienteId), Times.Once);
        }

        #endregion

    }
}