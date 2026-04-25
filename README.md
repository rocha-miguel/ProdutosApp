# 📦 ProdutosApp - API de Gestão de Produtos

<p align="center">
  <img src="https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet" alt=".NET 10">
  <img src="https://img.shields.io/badge/Entity_Framework-Core-0078D4?style=for-the-badge&logo=nuget" alt="EF Core">
  <img src="https://img.shields.io/badge/SQL_Server-Docker-CC292B?style=for-the-badge&logo=microsoft-sql-server" alt="SQL Server">
  <img src="https://img.shields.io/badge/Swagger-OAS3-85EA2D?style=for-the-badge&logo=swagger" alt="Swagger">
</p>

## 📌 Sobre o Projeto

O **ProdutosApp** é uma API RESTful moderna desenvolvida com o ecossistema **.NET 10**, projetada para oferecer uma gestão eficiente e escalável de produtos. O projeto segue princípios de **Clean Architecture** (Arquitetura em Camadas), garantindo separação de responsabilidades, alta testabilidade e fácil manutenção.

---

## 🛠️ Tecnologias Utilizadas

- **[C# & .NET 10](https://dotnet.microsoft.com/)**: Plataforma base e linguagem de desenvolvimento.
- **[Entity Framework Core](https://docs.microsoft.com/ef/core/)**: ORM (Object-Relational Mapper) para persistência e manipulação de dados.
- **[SQL Server](https://www.microsoft.com/sql-server)**: Banco de dados relacional.
- **[Docker & Docker Compose](https://www.docker.com/)**: Orquestração e containerização do ambiente de banco de dados independente e rápido.
- **[Scalar & Swagger/OpenAPI](https://swagger.io/)**: Documentação rica, interativa e amigável da API.

---

## 🏗️ Arquitetura e Estrutura do Projeto

A solução garante baixo acoplamento e possui uma dependência direcional, que é separada por padrão em **Três Camadas**:

### 1. `ProdutosApp.API` (Camada de Apresentação)
Ponto de entrada público da aplicação. Controladores (Controllers) lidam com o lado web da requisição e envio de retornos HTTP (Swagger/Scalar configurados aqui).

### 2. `ProdutosApp.Domain` (Camada de Domínio / Núcleo)
O componente mais importante do sistema, livre de dependências tecnológicas focadas.
- **Entities**: Contém as raízes da aplicação (ex: `Produto.cs`).
- **Enums**: Catalogo e restrições da sua aplicação (ex: `CategoriaProduto`, `StatusProduto`).

### 3. `ProdutosApp.Infra.Data` (Camada de Dados & Infraestrutura)
Interação exclusiva de dados com a persistência (geralmente banco local).
- **Contexts**: Configuração da classe fundamental do EF Core com `DataContext`.
- **Mappings / Repositories**: Encargos de CRUD e mapeamentos diretos das `Entities` para Tabelas.
- **Migrations**: Automação e versionamento para seu bando de dados em modo Code-First.

---

## 🚀 Como Executar o Projeto Localmente

### 📋 Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) instalado no ambiente local.
- Engine de Containerização como [Docker Desktop](https://www.docker.com/products/docker-desktop) ativa.

### 🏃‍♂️ Passos para Iniciar
1. **Ativar o Banco de Dados com Docker**
   Na raiz do repositório (onde reside o arquivo `docker-compose.yml`), rode o comando:
   ```bash
   docker-compose up -d
   ```
   *Isso irá subir o container do SQL Server na porta `1433` em segundo plano.*

2. **Aplicar Migrações e Atualizar o Banco**
   Sincronize sua base de dados antes de inicializar usando ferramentas do EF:
   ```bash
   dotnet ef database update --project ProdutosApp.Infra.Data --startup-project ProdutosApp.API
   ```

3. **Inicie o Servidor da API**
   Use a CLI para testar e validar:
   ```bash
   dotnet run --project ProdutosApp.API
   ```

4. **Acessando os Documentos e Interações**
   Após iniciar por terminal, verifique o Console pela URL do Host e adicione para uso amigável na interface via web:
   - Para visualização Scalar API: `http://localhost:<porta_aberta>/scalar`
   - Para o visual Swagger UI: `http://localhost:<porta_aberta>/swagger`

---

## 🔌 Catálogo de Endpoints

Funcionalidades de fácil consumo categorizadas por Rotas:

### 📦 Produtos (`/api/produtos`)
- `GET /api/produtos` — Busca todos os produtos ativos listados.
- `GET /api/produtos/{id}` — Extrai detalhes valiosos unicamente de um produto pelo identificador.
- `POST /api/produtos` — Rota segura e validada para criação de um novo produto.
- `PUT /api/produtos/{id}` — Substitui ou atualiza os inputs informativos do produto.
- `DELETE /api/produtos/{id}` — Deleta o produto de acordo com sua regra de exclusão.

### 📋 Enums / Auxiliares (`/api/enums`)
Dicionário prático para a camada frontend:
- `GET /api/enums/categorias` — Coleta do catálogo de sub-categorias.
- `GET /api/enums/status` — Extrai todas possíveis reações de status.

---
<p align="center">Feito com foco base em <b>Clean Architecture</b> para gerar código testável e adaptável.</p>
