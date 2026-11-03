# Projeto Damy — Sprint Flash .NET

## Sobre o projeto

A tecnologia nuclear está presente em diversas áreas, como saúde, agricultura, indústria, geração de energia e pesquisa científica. Mesmo assim, suas aplicações ainda são pouco conhecidas por parte da população.

O projeto Damy propõe uma plataforma educativa que utiliza jogos para aproximar as pessoas desse conhecimento. Por meio de atividades como quizzes, jogos da memória e quebra-cabeças, os participantes poderão aprender sobre tecnologia nuclear de forma interativa.

O propósito é estimular a curiosidade, apresentar aplicações presentes no cotidiano e incentivar a aprendizagem. Nas atividades competitivas, os jogadores poderão comparar seu desempenho a partir das pontuações obtidas.

## O que foi desenvolvido nesta sprint

Nesta Sprint Flash, desenvolvemos uma prova de conceito em **C#/.NET**, utilizando uma aplicação console no Visual Studio.

A funcionalidade escolhida foi o cadastro e a consulta de participações em sessões educativas. O programa representa uma pequena parte da solução, demonstrando como registrar quem participa de cada sessão e manter essas informações salvas.

A entidade utilizada é **Participação**, com os seguintes atributos:

- Identificador.
- Nome do usuário.
- Nome da sessão.
- Pontuação obtida.
- Data e horário de entrada.
- Status da participação.

## Integrantes — 2TDSPR

| Nome | RM |
|---|---|
| Luana Alves de Oliveira | 566621 |
| Isabely Marques da Silva | 566663 |
| Mateus Ribeiro Azevedo | 566630 |
| Paulo Gustavo Moraes de Sousa | 568580 |

## Funcionalidades

- Cadastrar uma nova participação.
- Listar todas as participações.
- Buscar participações pelo nome do usuário.
- Salvar e recuperar os registros em JSON.

## Validações e regra de negócio

Os nomes do usuário e da sessão são obrigatórios e devem conter pelo menos uma letra. Nomes como “Ana123” e “Quiz 1” são permitidos, mas valores somente numéricos são rejeitados.

Não é permitido cadastrar novamente o mesmo usuário na mesma sessão. As novas participações começam com zero pontos e status `aguardando`.

O programa utiliza `try/catch` para tratar erros de validação, regras de negócio e problemas na leitura ou gravação do arquivo.

## Como executar no Visual Studio

É necessário ter uma versão do **Visual Studio compatível com .NET 10**, com o SDK .NET 10 instalado.

1. Baixe ou clone o repositório.
2. Abra o Visual Studio.
3. Selecione **Abrir um projeto ou uma solução**.
4. Abra o arquivo de solução disponível no repositório (`.sln` ou `.slnx`) ou o arquivo do projeto (`.csproj`).
5. Se houver mais de um projeto, clique com o botão direito no projeto console e selecione **Definir como Projeto de Inicialização**.
6. Pressione **Ctrl + F5** para executar sem depuração ou **F5** para executar com depuração.
7. Utilize as opções do menu:

```text
1 - Cadastrar participação
2 - Listar todas as participações
3 - Buscar por nome do usuário
0 - Sair
```

## Persistência dos dados

Os registros são armazenados no arquivo:

```text
dados/participacoes.json
```

A pasta `dados` fica na raiz do projeto e é criada automaticamente no primeiro cadastro. O caminho completo do arquivo é exibido ao iniciar o programa.

Para verificar a persistência:

1. Cadastre uma participação.
2. Encerre o programa pela opção `0`.
3. Execute novamente no Visual Studio.
4. Escolha a opção `2` e confira o registro salvo.

## Como o .NET se aplica à solução

O .NET permite implementar a gestão das participações dos usuários nas sessões educativas. O C# organiza a entidade, valida os dados e aplica as regras de cadastro, enquanto o JSON mantém os registros disponíveis entre execuções. Essa funcionalidade complementa a entrega Java, responsável pela criação de sessões com tema. Nesta prova de conceito, os nomes são informados manualmente, sem integração direta com a API Java.