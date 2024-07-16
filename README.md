# Animecatalog

- Link domínio backend: https://animecatalogapi20240708203642.azurewebsites.net/swagger/index.html
  
- Link domínio frontend: https://tcc-frontend-sooty.vercel.app

## Identificação, proposta e solução
- Animecatalog tem o objetivo de resolver os problemas de quem está a procura de assistir ou conhecer alguma obra animada, em um sistema simples e direto.

- A ideia facilita a procura de uma obra, proporcionando um catálogo de obras com sua sinopse, podendo também adicionar a uma lista de desejos.

- Na prática, basta o usuário rolar pela página que encontrará as obras de acordo com seu gênero. Nesse sentido, a solução proposta é a praticidade na procura de algo novo.


## Escopo

**Desenvolvimento**

- O projeto será um sistema web, desenvolvido com C# e React. C# para desenvolvimento da API que retornará informações necessárias para realizar as funcionalidades das telas feitas com o React, e também para consumir uma API de listagem de obras animadas(https://docs.api.jikan.moe/#tag/anime), para filtragrem e visualização das obras em desejo.

**Qualidade do produto**

- Testes unitários serão implementados no backend para melhor cobertura de qualidade do projeto, utilizando o CodeCov para melhoria da qualidade nos cenários dos testes unitários.

## Restrições

- O sistema não fará reprodução de vídeos ou a opção de download dos episódios.
- O site não possui responsividade.

## Requisitos funcionais

Identificação                | Objetivo                                                                                 |
---------------------------- | ---------------------------------------------------------------------------------------- |
Navegar pelo site            | Visualizar os cards de diferentes gêneros das obras japonesas                            |
Utilizar o campo de pesquisa | Pesquisar o nome da obra para obter informações sobre                                    |
Registro                     | Se registrar para salvar os itens na lista para melhor controle do catálogo              |
Detalhes dos cards           | Capaz de clicar em um anime da lista para ver detalhes como sinopse, avaliação, etc.     |


## Trade-offs

- Portabilidade: O sistema não é adaptável para diferentes interfaces, sua capacidade de ser compilado em diferentes formatos é baixa. Necessário rodar em um browser de um laptop/computador. 
- Funcionalidade: O sistema não propõe várias funcionalidades, seu objetivo é ser simples e de fácil uso, tendo poucas funcionalidades, porém, indispensáveis. Podendo criar uma lista de desejo com os animes/obras que o usuário gostaria. As pesquisas e filtragens devem retornar resultados em no máximo 2 segundos.
- Confiabilidade: A confiabilidade gira em torno dos elementos selecionados que o usuário registrou em sua lista, ou seja, precisa estar logado com suas respectivas credenciais para gerenciar seus desejos.
- Usabilidade: Com a interface objetiva, a ideia é ter a usabilidade leve, para atender qualquer público que tenha interesse em animações da cultura japonesa. 
- Eficiência: Por ter uma proposta direta e simples, a interface é de fácil uso, sem mesmo precisar cadastrar-se para fazer pesquisas. 
- Manutenibilidade: O sistema pode apresentar problemas na renderização dos campos da tela, visto que não possui responsividade. O sistema também depende da funcionalidade da API que consome, sendo assim, em caso dela estar fora do ar, o sistema não vai conseguir realizar as requisições que precisa para coleta de informações.

## C4 Model

- [Acesse este caminho para ser redirecionado ao C4 Model.](files/c4-model.md)

## Casos de Uso

- [Acesse este caminho para ser redirecionado aos requisitos e os casos de uso.](files/requirements-nonrequirementsl.md)

# Documentação da Infraestrutura

## Implantação e Hospedagem no Azure

### 1. Ferramentas Utilizadas
- **Azure Web App**: Serviço de hospedagem para a API.
- **PostgreSQL**: Banco de dados relacional(hospegado na Vercel), configurado com a connection string.
- **GitHub Actions**: Serviço de CI/CD para automação da implantação.
- **Visual Studio**: IDE usada para desenvolvimento e configuração da implantação no Azure.

### 2. Configuração do GitHub Actions
O GitHub Actions é usado para automação do processo de CI/CD. O arquivo de configuração `.yml` é criado no repositório GitHub para definir os passos necessários para build, test e deploy da aplicação.

### 3. Etapas da publicação
- Opção de  "Publicar" diretamente na solução do projeto.
- Escolha "Azure" como destino de publicação.
- Faça login na sua conta Azure.
- Crie um novo Azure Web App.
- Espere pela criação da instância na hospedagem.
- Acesse o domínio do portal para prosseguir com as configurações da API.
- Acessar o recurso "App Services" e selecioar o Web App.
- Na seção "Configurações", adicionar as variáveis de ambiente necessárias para a aplicação.


## Modelagem por funcionalidade
- Com o próprio GitHub, na opção de Projetos, as tarefas estão sendo dividas em processos no estilo Kanban.
## Stack

- BE: C# e .Net Core 6.0
- FE:  React, Javascript e CSS.
- Database: PostgreSQL
- Qualidade nos cenários de testes: CodeCov (https://app.codecov.io/gh/fredericobwstein/tcc)
- Observalidade: Azure Application Insights
- ![image](https://github.com/fredericobwstein/tcc/assets/61890758/eb15cdbe-ee8e-42ef-9280-1d75d0e4f2bb)


## Rodar localmente o projeto
- Ferramentas: PostgreSQL (PgAdmin 4), VisualStudio Community, Runtime do .Net Core 6.0
- Clonar o repositório do back-end (este mesmo em questão)
- No arquivo appsettings.json, configurar no DefaultConnection a conexão com o banco de dados
- Crie uma database com o nome animecatalog e execute o script SQL das tabelas do sistema.
- Execute a aplicação do backend.
- Clonar o repositório do front-end(https://github.com/fredericobwstein/tcc-frontend) e execute o seguinte comando: `npm i`
- Crie um arquivo chamando `.env` e adicione a seguinte informação: `REACT_APP_XD=https://localhost:7281`. Lembre-se de colocar a URL do localhost do seu backend local.
- Execute o seguinte comando: `npm start`
