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