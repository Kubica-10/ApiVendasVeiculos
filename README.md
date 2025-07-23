#  API Profissional de Vendas de Veículos com .NET 8

![C#](https://img.shields.io/badge/C%23-12.0-blue?logo=c-sharp) ![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet?logo=dotnet) ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoft-sql-server&logoColor=white) ![Status](https://img.shields.io/badge/status-conclu%C3%ADdo-green)

## 📄 Sobre o Projeto

Este projeto é uma API RESTful completa para um sistema de Vendas de Veículos, construída do zero com ASP.NET Core 8 (usando o template de API Mínima) e C#. O objetivo foi aplicar e demonstrar conceitos essenciais de desenvolvimento backend, transformando um simples desafio em uma aplicação robusta e alinhada com as práticas do mercado.

A aplicação se conecta a um banco de dados SQL Server real e persistente, gerenciado inteiramente via código através do Entity Framework Core, e expõe uma interface de documentação interativa com Swagger.

## ✨ Funcionalidades Principais

A API implementa todas as operações CRUD (Create, Read, Update, Delete) para o gerenciamento de veículos:

- `GET /veiculos`: Retorna uma lista com todos os veículos cadastrados no banco de dados.
- `GET /veiculos/{id}`: Busca e retorna os dados de um veículo específico pelo seu ID.
- `POST /veiculos`: Adiciona um novo veículo ao banco de dados.
- `PUT /veiculos/{id}`: Atualiza todas as informações de um veículo existente.
- `DELETE /veiculos/{id}`: Remove um veículo do banco de dados.

A aplicação também inclui tratamento de erros, como retornar `404 Not Found` caso um veículo não seja encontrado.

## 🛠️ Tecnologias e Conceitos-Chave

Este projeto foi uma oportunidade para aplicar e demonstrar conhecimento nas seguintes tecnologias e conceitos:

- **Linguagem e Plataforma:** C# e .NET 8
- **Framework Web:** ASP.NET Core 8 (API Mínima)
- **Banco de Dados:** SQL Server
- **ORM (Object-Relational Mapper):** **Entity Framework Core (EF Core)**, utilizado para abstrair o acesso ao banco de dados.
- **Padrão Code-First:** A estrutura do banco de dados (tabelas e colunas) é gerada e gerenciada diretamente a partir das classes C# (`Veiculo.cs`).
- **Migrations:** Ferramenta do EF Core utilizada para criar e atualizar o schema do banco de dados de forma versionada e segura.
- **Injeção de Dependência:** Utilizada pelo ASP.NET Core para gerenciar o ciclo de vida do `ApiDbContext`, fornecendo a conexão com o banco de dados para os endpoints de forma eficiente.
- **Documentação de API:** Geração automática de uma interface de testes interativa com **Swagger (OpenAPI)**.

## 🚀 Como Executar o Projeto

Para executar este projeto, você precisará ter o .NET 8 SDK e o SQL Server (versão Express ou superior) instalados.

**1. Clone o repositório:**
   ```bash
   git clone [https://github.com/Kubica-10/ApiVendasVeiculos.git](https://github.com/Kubica-10/ApiVendasVeiculos.git)
2. Navegue até a pasta do projeto:

Bash

cd ApiVendasVeiculos
3. Configure o Banco de Dados:

Abra o arquivo appsettings.json.

Se necessário, ajuste a ConnectionString para apontar para a sua instância do SQL Server. A padrão é Server=localhost\\SQLEXPRESS;....

No terminal, execute o comando abaixo para que o Entity Framework crie o banco de dados VendasVeiculos e a tabela Veiculos para você:

Bash

dotnet ef database update
4. Execute a API:

Com o banco de dados criado, inicie a aplicação:

Bash

dotnet run
O terminal informará o endereço onde a API está rodando (ex: http://localhost:5250).

5. Teste com o Swagger:

Abra seu navegador e acesse o endereço da aplicação seguido de /swagger.

Exemplo: http://localhost:5250/swagger

Você verá a interface interativa para testar todos os endpoints.

✒️ Autor
Helemberg Cubiça