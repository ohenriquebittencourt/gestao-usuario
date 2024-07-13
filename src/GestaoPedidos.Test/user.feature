Feature: User

Scenario: Obter Usuario
	Given acessar a rota de busca de usuario
	When eu efetuar a requisicao de busca de usuario
	Then obter os usuario com sucesso

Scenario: Obter Usuarios
	Given acessar a rota de busca varios usuarios
	When eu efetuar a requisicao de busca de usuarios
	Then obter os usuarios com sucesso

Scenario: Cadastrar Usuario
	Given acessar a rota de cadastro de usuario
	And eu tenho os dados do usuario
	When eu enviar a requisicao de cadastro
	Then cadastrar um usuario com sucesso

Scenario: Atualizar Usuario
	Given acessar a rota de atualizacao de usuario
	And eu tenho os dados do usuario atualizado
	When eu enviar a requisicao de atualizacao
	Then atualizar um usuario com sucesso

Scenario: Deletar Usuario
	Given acessar a rota de delete
	And eu tenho o id do usuario
	When eu enviar a requisicao de delete
	Then deletar um usuario com sucesso
