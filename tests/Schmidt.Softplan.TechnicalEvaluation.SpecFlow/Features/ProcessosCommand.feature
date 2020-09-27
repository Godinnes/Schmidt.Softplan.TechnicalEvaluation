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

Scenario: Cadastrar um processo correto
	Given a processo número '3513042-04.2016.8.19.0423', descrição 'Primeiro processo', Situacao 'Em andamento', Responsáveis 'Carolina Clarice Moreira', Pasta do cliente 'CaminhoPasta', data de distribuição '27/09/2020' e Segredo de justiça 'Não'
	Then possuo um processo

Scenario: Cadastrar um processo correto sem pasta
	Given a processo número '3513042-04.2016.8.19.0423', descrição 'Primeiro processo', Situacao 'Em andamento', Responsáveis 'Carolina Clarice Moreira', Pasta do cliente '', data de distribuição '' e Segredo de justiça 'Não'
	Then possuo um processo

Scenario: Cadastrar duas vezes o mesmo processo
	Given a processo número '3513042-04.2016.8.19.0500', descrição 'Primeiro processo', Situacao 'Em andamento', Responsáveis 'Carolina Clarice Moreira', Pasta do cliente 'CaminhoPasta', data de distribuição '27/09/2020' e Segredo de justiça 'Não'
	And a processo número '3513042-04.2016.8.19.0500', descrição 'Primeiro processo', Situacao 'Em recurso', Responsáveis 'Benício Heitor Galvão', Pasta do cliente 'CaminhoPasta', data de distribuição '27/09/2020' e Segredo de justiça 'Não'
	Then I have a exception 'Já existe um processo com este número.'

Scenario: Cadastrar um processo sem número do processo
	Given a processo número '', descrição 'Primeiro processo', Situacao 'Em andamento', Responsáveis 'Carolina Clarice Moreira', Pasta do cliente 'CaminhoPasta', data de distribuição '' e Segredo de justiça 'Não'
	Then I have a exception 'Número de processo unificado é obrigatório.'

Scenario: Cadastrar um processo com número do processo inválido
	Given a processo número '123123123', descrição 'Primeiro processo', Situacao 'Em andamento', Responsáveis 'Carolina Clarice Moreira', Pasta do cliente 'CaminhoPasta', data de distribuição '' e Segredo de justiça 'Não'
	Then I have a exception 'Número de processo unificado precisa 20 catacteres.'

Scenario: Cadastrar um processo sem responsável
	Given a processo número '3513042-04.2016.8.19.0424', descrição 'Segundo processo', Situacao 'Desmenbrado', Responsáveis '', Pasta do cliente 'CaminhoPasta', data de distribuição '' e Segredo de justiça 'Não'
	Then I have a exception 'É obrigatório informar um responsável.'

Scenario: Cadastrar um processo com três responsaveis
	Given a processo número '3513042-04.2016.8.19.0421', descrição 'Segundo processo', Situacao 'Desmenbrado', Responsáveis 'Carolina Clarice Moreira, Benício Heitor Galvão, Elisa Nina Marlene Castro, Raimunda Laura Farias', Pasta do cliente 'CaminhoPasta', data de distribuição '' e Segredo de justiça 'Não'
	Then I have a exception 'Não pode informar mais de 3 responsáveis.'

Scenario: Cadastrar um processo com responsaveis duplicados
	Given a processo número '3513042-04.2016.8.19.0421', descrição 'Segundo processo', Situacao 'Desmenbrado', Responsáveis 'Carolina Clarice Moreira, Benício Heitor Galvão, Benício Heitor Galvão', Pasta do cliente 'CaminhoPasta', data de distribuição '' e Segredo de justiça 'Não'
	Then I have a exception 'Não pode informar mais de uma vez um responsável.'

Scenario: Cadastrar um processo com uma data superior ao do dia
	Given a processo número '3513042-04.2016.8.19.0421', descrição 'Segundo processo', Situacao 'Desmenbrado', Responsáveis 'Carolina Clarice Moreira, Benício Heitor Galvão', Pasta do cliente 'CaminhoPasta', data de distribuição '28/09/2020' e Segredo de justiça 'Não'
	Then I have a exception 'A data de distribuição não pode ser posterior a data atual.'

Scenario: Cadastrar um processo com uma pasta que passa de 50 caracteres
	Given a processo número '3513042-04.2016.8.19.0421', descrição 'Segundo processo', Situacao 'Desmenbrado', Responsáveis 'Carolina Clarice Moreira, Benício Heitor Galvão', Pasta do cliente 'C:\src\Godinnes\Schmidt.Softplan.TechnicalEvaluation\src\Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler\Implementation', data de distribuição '' e Segredo de justiça 'Não'
	Then I have a exception 'Pasta física cliente não pode ter mais de 50 caracteres.'

Scenario: Cadastrar um processo com uma descrição que passa de 1000 caracteres
	Given a processo número '3513042-04.2016.8.19.0421', descrição 'No mundo atual, a necessidade de renovação processual ainda não demonstrou convincentemente que vai participar na mudança dos níveis de motivação departamental. Evidentemente, a complexidade dos estudos efetuados obstaculiza a apreciação da importância dos modos de operação convencionais. Pensando mais a longo prazo, o desenvolvimento contínuo de distintas formas de atuação agrega valor ao estabelecimento do orçamento setorial.Percebemos, cada vez mais, que a contínua expansão de nossa atividade pode nos levar a considerar a reestruturação das formas de ação. Gostaria de enfatizar que a expansão dos mercados mundiais não pode mais se dissociar das posturas dos órgãos dirigentes com relação às suas atribuições. A prática cotidiana prova que o entendimento das metas propostas deve passar por modificações independentemente do retorno esperado a longo prazo.Por conseguinte, o desafiador cenário globalizado possibilita uma melhor visão global das novas proposições. Pensando mais a longo prazo, a crescente influência da mídia estimula a padronização de todos os recursos funcionais envolvidos.', Situacao 'Desmenbrado', Responsáveis 'Carolina Clarice Moreira, Benício Heitor Galvão', Pasta do cliente '', data de distribuição '' e Segredo de justiça 'Não'
	Then I have a exception 'Descrição não pode teer mais de 1000 caracteres.'

Scenario: Cadastrar um processo sem situação
	Given a processo número '3513042-04.2016.8.19.0423', descrição 'Primeiro processo', Situacao '', Responsáveis 'Carolina Clarice Moreira', Pasta do cliente 'CaminhoPasta', data de distribuição '27/09/2020' e Segredo de justiça 'Não'
	Then I have a exception 'Situação é obrigatório.'