@ProcessosCommand
Feature: Processos cadastro
	Validar cadastro de processos

Background: 
	Given The follow situacões
		| Nome         | Finalizado |
		| Em andamento | Não        |
		| Desmenbrado  | Não        |
		| Em recurso   | Não        |
		| Finalizado   | Sim        |
		| Arquivado    | Sim        |

	Given The follow responsáveis
		| Nome                      | CPF            | Email                                                          |
		| Carolina Clarice Moreira  | 187.502.927-30 | ccarolinaclaricemoreira@pontofinalcafe.com.br                  |
		| Benício Heitor Galvão     | 696.365.405-00 | benicioheitorgalvao_@simoesmendonca.adv.br                     |
		| Elisa Nina Marlene Castro | 159.943.355-92 | elisaninamarlenecastro__elisaninamarlenecastro@doublemoore.com |
		| Raimunda Laura Farias     | 080.629.132-01 | raimundalaurafarias_@fepextrusao.com.br                        |

Scenario: Cadastrar uma processo correto
	Given a processo número '3513042-04.2016.8.19.0423', descrição 'Primeiro processo', Situacao 'Em andamento', Responsáveis 'Carolina Clarice Moreira' e Segredo de justiça 'Não'
	Then possuo um processo

Scenario: Cadastrar uma processo sem responsável
	Given a processo número '3513042-04.2016.8.19.0424', descrição 'Segundo processo', Situacao 'Desmenbrado', Responsáveis '' e Segredo de justiça 'Não'
	Then I have a exception 'É obrigatório informar um responsável.'

Scenario: Cadastrar uma processo com três responsaveis
	Given a processo número '3513042-04.2016.8.19.0421', descrição 'Segundo processo', Situacao 'Desmenbrado', Responsáveis 'Carolina Clarice Moreira, Benício Heitor Galvão, Elisa Nina Marlene Castro, Raimunda Laura Farias' e Segredo de justiça 'Não'
	Then I have a exception 'Não pode informar mais de 3 responsáveis.'

Scenario: Cadastrar uma processo com responsaveis duplicados
	Given a processo número '3513042-04.2016.8.19.0421', descrição 'Segundo processo', Situacao 'Desmenbrado', Responsáveis 'Carolina Clarice Moreira, Benício Heitor Galvão, Benício Heitor Galvão' e Segredo de justiça 'Não'
	Then I have a exception 'Não pode informar mais de uma vez um responsável.'