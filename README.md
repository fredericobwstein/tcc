# Animecatalog

Link domínio backend: https://animecatalogapi20240708203642.azurewebsites.net/swagger/index.html 
Link domínio frontend: https://tcc-frontend-sooty.vercel.app

## Identificação, proposta e solução
- Animecatalog tem o objetivo de resolver os problemas de quem está a procura de assistir ou conhecer alguma obra animada, em um sistema simples e direto.

- A ideia facilita a procura de uma obra, proporcionando um catálogo de obras com sua sinopse, podendo também adicionar a uma lista de desejos.

- Na prática, basta o usuário rolar pela página que encontrará as obras de acordo com seu gênero. Nesse sentido, a solução proposta é a praticidade na procura de algo novo.


## Escopo

**Desenvolvimento**

- O projeto será um sistema web, desenvolvido com C# e React. C# para desenvolvimento da API que retornará informações necessárias para realizar as funcionalidades das telas feitas com o React, e também para consumir uma API de listagem de obras animadas, para filtragrem e visualização das obras em desejo.

**Qualidade do produto**

- Testes unitários serão implementados no backend para melhor cobertura de qualidade do projeto, utilizando o CodeCov para melhoria da qualidade nos cenários dos testes unitários.

## Restrições

- O sistema não fará reprodução de vídeos ou a opção de download dos episódios.

## C4 Model

- [Acesse este caminho para ser redirecionado ao C4 Model.](files/c4-model.md)

## Requisitos e Casos de Uso

- [Acesse este caminho para ser redirecionado aos requisitos e os casos de uso.](files/requirements-nonrequirementsl.md)

## Modelagem por funcionalidade
- Com o próprio GitHub, na opção de Projetos, as tarefas estão sendo dividas em processos no estilo Kanban.
## stack

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
- Execute o seguinte comando: `npm run dev`
