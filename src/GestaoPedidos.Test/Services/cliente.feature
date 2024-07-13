Feature: Cliente

Scenario: Obter Cliente
	Given acessar a rota de busca
	When eu efetuar a requisicao com cpf
	Then obter os clientes com sucesso

Scenario: Cadastrar Cliente
	Given acessar a rota de cadastro
	And eu tenho os dados do cliente
	When eu enviar a requisicao
	Then cadastrar um cliente com sucesso

Scenario: Atualizar Cliente
	Given acessar a rota de atualizacao
	And eu tenho os dados do cliente atualizado
	When eu enviar a requisicao de atualizacao
	Then atualizar um cliente com sucesso

Scenario: Deletar Cliente
	Given acessar a rota de delete
	And eu tenho o id do cliente
	When eu enviar a requisicao de delete
	Then deletar um cliente com sucesso
