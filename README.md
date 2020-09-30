
# Avaliação Técnica Softplan

Esta implementação está disponível no link: [App Avaliação Técnica](https://schmidtsoftplantechnicalevaluation-dev-as.azurewebsites.net/swagger/index.html).
O intuito desse link é facilitar a avaliação, sem exigir que quem vá avaliar precise aprender como rodar.

Desenvolvido com Visual Studio 2019 Community, o qual pode ser baixado no link: [Visual Studio](https://visualstudio.microsoft.com/pt-br/vs/community/).
Baixar o Docker no link: [Docker](https://docs.docker.com/docker-for-windows/install/).
Baixar o Git no link: [Git](https://github.com/git-for-windows/git/releases/download/v2.28.0.windows.1/Git-2.28.0-64-bit.exe).
Para instalar, só precisa seguir os wizards de cada instalador.

Para baixar o código, pode-se criar um pasta onde deseja que o código seja baixado, com o botão direito clique em Git Bash Here.
Abrirá um console, agora cole o texto:

> git clone https://github.com/Godinnes/Schmidt.Softplan.TechnicalEvaluation

e pressione enter.
Após baixar o código, na pasta que foi criada após executar o comando, encontrará o arquivo **Schmidt.Softplan.TechnicalEvaluation.sln**, clique duas vezes, abrirá o Visual Studio.
Na parte superior do Visual Studio, existe um seta verde que ao lado está escrito "IIS Express", altere para "Docker", após isso pode clicar na seta, então será compilado o código e abrirá uma página com o final "swagger".

## Testar a aplicação
Para testar da aplicação, o Swagger gera uma interface amigável com as ações disponíveis.

Pode-se clicar no **Get /Situacoes/Busca**, logo em seguida **Try it out** e **Execute**, assim requisitará todas as situações cadastradas no sistema.
Copie um ID para podermos usar logo em seguida.

Em **Post /Responsaveis** cadastraremos um responsável, pode clicar no link, depois em **Try it out**.
Veja que foi criado um Json com o que deve-se informar para cadastrar um responsável.

Exemplo:
`{ "nome": "Lucca Luís da Rocha",
  "cpf": "930.821.250-77",
  "email": "aqui tu pode informar o seu e-mail",
  "foto": null
}`

Pode subistituir o texto por este exemplo, e clicar em **Execute**, assim gravará a nova pessoa.
Para ver se está realmente gravado, pode ir em **Get /Responsaveis/Busca** clicar no link, **Try it out** e **Execute**.
Copie o ID da pessoa para usar logo em seguida.

Vamos cadastrar um processo agora.
Em **Post /Processos** ao clicar, **Try it out**, pode subistituir o texto pelo exemplo:

Exemplo: 

`{
  "numeroProcessoUnificado": "3513042-04.2016.8.19.0423",
  "distribuicao": null,
  "pastaFisicaCliente": null,
  "descricao": "Meu primeiro processo",
  "situacaoID": "Cole aqui o ID da situação",
  "responsaveis": [
    "Cole aqui o ID do responsável"
  ],
  "segredoJustica": false,
  "processoPaiID": null
}`

Lembre-se de subistituir **situacaoID** e **responsaveis** pelos IDs que tenha salvo.
Clique em **Execute**, assim salvará o processo.

Pode clicar em **Get /Processos/Busca**, em **Try it out** e em **Execute** para ver os processos cadastrados.

Agora, possui o básico para usar a aplicação, pode se divertir avaliando.
