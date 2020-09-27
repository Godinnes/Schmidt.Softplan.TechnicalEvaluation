@ResponsaveisCommand
Feature: Responsaveis cadastro
	Validação dos responsáveis

Scenario: Cadastrando um responsável com informações corretas
	Given a responsavel 'Vitor Carlos da Conceição', CPF '173.234.992-40', Email 'vvitorcarlosdaconceicao@landovale.com.br'
	Then I have a responsavel

Scenario: Cadastrando um responsável com CPF inválido
	Given a responsavel 'Danilo Miguel João da Mota', CPF '983.953.662-12', Email 'ddanilomigueljoaodamota@mx.labinal.com'
	Then I have a exception 'CPF não é válido.'

Scenario: Cadastrando um responsável sem CPF
	Given a responsavel 'Felipe Breno Cavalcanti', CPF '', Email 'felipebrenocavalcanti..felipebrenocavalcanti@superigi.com.br'
	Then I have a exception 'CPF é obrigatório.'

Scenario: Cadastrando um responsável sem nome
	Given a responsavel '', CPF '643.034.737-07', Email 'raimundolorenzofilipeoliveira-73@abdalathomaz.adv.br'
	Then I have a exception 'Nome do responsável é obrigatório.'

Scenario: Cadastrando um responsável com nome gigantesco
	Given a responsavel 'Sarah Helena Josefa da Cunha Miguel João da Mota Carlos da Conceição Sarah Helena Josefa da Cunha Miguel João da Mota Carlos da Conceição Sarah Helena Josefa da Cunha Miguel João da Mota Carlos da Conceição', CPF '758.497.565-82', Email 'sarahhelenajosefadacunha-78@premierpet.com.br'
	Then I have a exception 'Nome não pode ter mais de 150 caracteres.'

Scenario: Cadastrando um responsável sem email
	Given a responsavel 'Liz Luciana Jennifer Barros', CPF '686.287.803-43', Email ''
	Then I have a exception 'E-mail é obrigatório.'

Scenario: Cadastrando um responsável com email inválido
	Given a responsavel 'Elza Fernanda Brenda Figueiredo', CPF '637.816.887-39', Email 'elzafernandabrendafigueiredo__elzafernandabrendafigueiredo@'
	Then I have a exception 'E-mail não é válido.'

Scenario: Cadastrando um responsável com email gigantesco
	Given a responsavel 'Aparecida Josefa Fogaça', CPF '117.815.631-10', Email 'aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_aparecidajosefafogaca_@santarte.com'
	Then I have a exception 'E-mail não pode ter mais de 400 caracteres.'

Scenario: Cadastrando duas vezes um responsável com mesmo CPF
	Given a responsavel 'Vitória Aurora Moreira', CPF '885.056.705-74', Email 'vitoriaauroramoreira_@a-qualitybrasil.com.br'
	And a responsavel 'Joana Isis Assunção', CPF '885.056.705-74', Email 'joanaisisassuncao..joanaisisassuncao@devuono.com.br'
	Then I have a exception 'Já existe um responsável com este CPF.'