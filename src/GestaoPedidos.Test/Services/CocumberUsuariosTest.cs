using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Application.Services;
using System.Diagnostics.CodeAnalysis;
using GestaoPedidos.Domain.Entities;
using Xunit.Gherkin.Quick;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedidos.Test.Services
{
    [FeatureFile("Services/usuario.feature")]
    public sealed class CocumberUsuariosTest : Feature
    {
        private readonly Mock<IUsuarioRepository> _mockRepository;
        private readonly UsuarioService _mockService;
        private Usuario _usuario;
        private int _usuarioId = 1;

        public CocumberUsuariosTest()
        {
            _mockRepository = new Mock<IUsuarioRepository>();
            _mockService = new UsuarioService(_mockRepository.Object);
        }

        #region OBTER

        [Given(@"acessar a rota de busca de usuario")]
        public void Acessar_rota_de_busca_usuario()
        {
            var url = $"https://seusite.com/api/usuario";
        }

        [When(@"eu efetuar a requisicao de busca de usuario")]
        public async Task efetuar_requisicao_busca_usuario()
        {
            _mockRepository.Setup(repo => repo.Obter(_usuarioId)).ReturnsAsync(new Usuario(1, "Henrique", "henrique@gmail.com", "1234", 1, true));
            var result = await _mockService.ObterUsuario(_usuarioId);
        }

        [Then(@"obter os usuario com sucesso")]
        public void obter_um_usuario_com_sucesso()
        {
            _mockRepository.Verify(repo => repo.Obter(_usuarioId), Times.Once);
        }

        #endregion

        #region OBTER MAIS DE UM

        [Given(@"acessar a rota de busca de usuarios")]
        public void Acessar_rota_de_busca_usuarioS()
        {
            var url = $"https://seusite.com/api/usuario";
        }

        [When(@"eu efetuar a requisicao de busca de usuarios")]
        public async Task efetuar_requisicao_busca_usuarioS()
        {
            var usuarios = new List<Usuario>
            {
                new Usuario(1, "Henrique", "henrique@gmail.com", "1234", 1, true),
                new Usuario(2, "Yan", "yan@gmail.com", "5678", 1, true),
                new Usuario(3, "Artur", "artur@gmail.com", "4321", 1, true)
            }.AsQueryable();

            _mockRepository.Setup(repo => repo.Obter()).ReturnsAsync(usuarios);
            var result = await _mockService.ObterUsuarios();
        }

        [Then(@"obter os usuarios com sucesso")]
        public void obter_um_usuarios_com_sucesso()
        {
            _mockRepository.Verify(repo => repo.Obter(), Times.Once);
        }

        #endregion

        #region CADASTRAR

        [Given(@"acessar a rota de cadastro de usuario")]
        public void acessar_rota_de_cadastro()
        {
            var url = $"https://seusite.com/api/usuario";
        }

        [And(@"eu tenho os dados do usuario")]
        public void tenho_dados_do_usuario_cadastro()
        {
            _usuario = new Usuario(1, "Henrique", "henrique@gmail.com", "1234", 1, true);
        }

        [When(@"eu enviar a requisicao de cadastro")]
        public async Task efetuar_requisicao_cadastro()
        {
            _mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<Usuario>())).Returns(Task.CompletedTask);
            await _mockService.CadastrarUsuario(_usuario);
        }

        [Then(@"cadastrar um usuario com sucesso")]
        public void cadastrar_um_usuario_com_sucesso()
        {
            _mockRepository.Verify(repo => repo.Cadastrar(_usuario), Times.Once);
        }

        #endregion

        #region ATUALIZAR

        [Given(@"acessar a rota de atualizacao de usuario")]
        public void acessar_rota_de_atualizacao_usuario()
        {
            var url = $"https://seusite.com/api/usuario";
        }

        [And(@"eu tenho os dados do usuario atualizado")]
        public void tenho_dados_do_usuario_atualizacao()
        {
            _usuario = new Usuario(1, "Henrique", "henrique@gmail.com", "1234", 1, true);
        }

        [When(@"eu enviar a requisicao de atualizacao")]
        public async Task efetuar_requisicao_atualizacao()
        {
            _mockRepository.Setup(repo => repo.Atualizar(It.IsAny<Usuario>())).Returns(Task.CompletedTask);
            await _mockService.AtualizarUsuario(_usuario);
        }

        [Then(@"atualizar um usuario com sucesso")]
        public void atualizar_um_usuario_com_sucesso()
        {
            _mockRepository.Verify(repo => repo.Atualizar(_usuario), Times.Once);
        }

        #endregion

        #region DELETAR

        [Given(@"acessar a rota de delete")]
        public void acessar_rota_de_delete()
        {
            var url = $"https://seusite.com/api/usuario";
        }

        [And(@"eu tenho o id do usuario")]
        public void tenho_id_do_usuario_delete()
        {
            _usuarioId = 1;
        }

        [When(@"eu enviar a requisicao de delete")]
        public async Task efetuar_requisicao_delete()
        {
            _mockRepository.Setup(repo => repo.Remover(_usuarioId)).Returns(Task.CompletedTask);
            await _mockService.RemoverUsuario(_usuarioId);
        }

        [Then(@"deletar um usuario com sucesso")]
        public void delete_um_usuario_com_sucesso()
        {
            _mockRepository.Verify(repo => repo.Remover(_usuarioId), Times.Once);
        }

        #endregion

    }
}