@ProcessosQuery
Feature: Processos busca
	Validação das buscas dos processos

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
		| NumeroProcessoUnificado   | Descricao         | Distribuicao | SegredoJustica | Pasta            | Situacao     | Responsaveis                                                            |
		| 3513042-04.2016.8.19.0423 | Primeiro Processo | 01/05/2020   | Não            | caminho de pasta | Em andamento | Benício Heitor Galvão, Elisa Nina Marlene Castro                        |
		| 3513040-04.2016.8.19.0421 | Segundo Processo  | 02/06/2020   | Não            |                  | Desmenbrado  | Raimunda Laura Farias, Carolina Clarice Moreira                         |
		| 3513040-04.2016.8.19.0422 | Terceiro Processo | 01/10/2019   | Não            |                  | Desmenbrado  | Raimunda Laura Farias                                                   |
		| 3513040-04.2016.8.19.0425 | Quarto Processo   |              | Não            |                  | Em recurso   | Raimunda Laura Farias, Benício Heitor Galvão , Carolina Clarice Moreira |

Scenario: Busco por todos os processos
	Given busca por todos
	Then possuo 4 processos

Scenario: Busco por todos de forma paginada
	Given busca de '0' a '2'
	And busca de '2' a '4'
	Then possuo 4 processos

Scenario: Busco por processos informando o número do processo unificado formatado
	Given busca pelo número processo unificado '3513042-04.2016.8.19.0423'
	Then possuo 1 processos

Scenario: Busco por processos informando o número do processo unificado não formatado
	Given busca pelo número processo unificado '35130400420168190425'
	Then possuo 1 processos

Scenario: Busco por processos informando o período da distribuição
	Given busca pelo período de distribuição '01/05/2020' e '01/07/2020'
	Then possuo 2 processos

Scenario: Busco por processos informando parte da pasta física cliente
	Given busca por parte da pasta física cliente 'de'
	Then possuo 1 processos

Scenario: Busco por processos informando uma situação
	Given busco pela situação 'Desmenbrado'
	Then possuo 2 processos

Scenario: Busco por processos informando parte do nome do responsável
	Given busca pelo responsável 'Farias'
	Then possuo 3 processos