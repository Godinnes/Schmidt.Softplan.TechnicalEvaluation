@ResponsaveisQuery
Feature: Responsaveis Busca
	Validação das buscas

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

	Given The follow processos
		| NumeroProcessoUnificado   | Descricao         | Distribuicao | SegredoJustica | Situacao     | Responsaveis                                     |
		| 3513042-04.2016.8.19.0423 | Primeiro Processo |              | Não            | Em andamento | Benício Heitor Galvão, Elisa Nina Marlene Castro |
		| 3513040-04.2016.8.19.0423 | Segundo Processo  |              | Não            | Desmenbrado  | Raimunda Laura Farias, Carolina Clarice Moreira  |

Scenario: Buscar todos os responsáveis
	Given uma busco por todos
	Then a quantidade de responsáveis encontrados deveria ser 4

Scenario: Buscar por nome dos responsáveis
	Given uma busca pelo nome 'ra'
	Then a quantidade de responsáveis encontrados deveria ser 2

Scenario: Buscar por CPF formatado dos responsáveis
	Given uma busca pelo CPF '187.502.927-30'
	Then a quantidade de responsáveis encontrados deveria ser 1

Scenario: Buscar por CPF não formatado dos responsáveis
	Given uma busca pelo CPF '15994335592'
	Then a quantidade de responsáveis encontrados deveria ser 1

Scenario: Buscar pelo número do processo unificado não formatado dos responsáveis
	Given uma busca pelo número do processo unificado '35130420420168190423'
	Then a quantidade de responsáveis encontrados deveria ser 2

Scenario: Buscar pelo número do processo unificado formatado dos responsáveis
	Given uma busca pelo número do processo unificado '3513040-04.2016.8.19.0423'
	Then a quantidade de responsáveis encontrados deveria ser 2