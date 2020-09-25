Feature: Business Rules about Responsavel
	AA

@Responsavel
Scenario: Cadastrando um responsável com informações corretas
	Given a responsavel Vitor Carlos da Conceição, CPF 173.234.992-40, Email vvitorcarlosdaconceicao@landovale.com.br
	Then I have a responsavel


Scenario: Cadastrando um responsável com CPF inválido
	Given a responsavel Danilo Miguel João da Mota, CPF 983.953.662-12, Email ddanilomigueljoaodamota@mx.labinal.com
	Then I have a responsavel