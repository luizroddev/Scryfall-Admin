# Scryfall Admin

## Visão geral

O Scryfall Admin é um aplicativo MVC em .NET que permite administrar cartas do Scryfall. Este projeto inclui um CRUD (Create, Read, Update, Delete) completo para gerenciar informações sobre cartas.

## Changelog

### Versão 1.0.0 - Lançada em 7 de outubro de 2023

**Refatoração:**
- Adicionou chaves estrangeiras e renomeou modelos para melhorar a estrutura do banco de dados.

**Novo recurso:**
- Criou modelo, visualização e controlador para cartas com imagens URI.
- Criou modelo, visualização e controlador para a legalidade das cartas.
- Adicionou variáveis de chaves estrangeiras para imagens URI e legalidades.
- Implementou caching e consultas de chaves estrangeiras nas visualizações.
- Criou visualizações para cartas e implementou seleção de chaves estrangeiras.

**Correção:**
- Removidas migrações não utilizadas e atualizado o modelo de banco de dados.

**Novo recurso:**
- Implementou novos dbsets e criou relacionamentos entre entidades.
- Adicionou serviço de cache em memória.

## Pré-requisitos

Certifique-se de ter os seguintes pré-requisitos instalados antes de executar o projeto:

- .NET SDK 5.0 ou superior
- Visual Studio
- Oracle ou Postgres (já estão configurados)

## Configuração do Banco de Dados

Antes de iniciar o aplicativo, configure a conexão com o banco de dados em `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "oracle"
}
```

Depois disso, execute as migrações para criar o banco de dados:

```bash
dotnet ef database update
```

## Executando o Aplicativo

Para executar o aplicativo, use os seguintes comandos:

```bash
dotnet restore
dotnet run
```

O aplicativo estará acessível em `https://localhost:5001` (ou `http://localhost:5000`).

Aproveite o uso do Scryfall Card Manager para gerenciar suas cartas do Scryfall! Se você tiver alguma dúvida ou encontrar problemas, sinta-se à vontade para entrar em contato conosco.
