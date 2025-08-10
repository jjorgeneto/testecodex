# Projeto: Clientes API (.NET 8)

API Web para gestão de clientes com arquitetura Onion, JWT, EF Core + PostgreSQL, Docker e testes xUnit.

## Tecnologias
- .NET 8
- ASP.NET Core Web API
- EF Core + Npgsql
- JWT Bearer Auth
- Docker / docker-compose
- xUnit

## Estrutura
`
/src
  /Domain
  /Application
  /Infrastructure
  /Api
/tests
  /Api.Tests
`

## Executar (sem Docker)
1. Crie o banco local (se preferir Docker, veja a seção abaixo):
   - PostgreSQL rodando e um DB chamado `clientes_db`.
2. Ajuste a connection string em `src/Api/appsettings.Development.json` (por padrão usa `Host=localhost;Port=5432;Database=clientes_db;Username=postgres;Password=postgres`).
3. Rodar migrations:
   `bash
   dotnet tool install --global dotnet-ef
   dotnet restore
   dotnet build
   dotnet ef database update --project src/Infrastructure --startup-project src/Api
   `
4. Executar API:
   `bash
   dotnet run --project src/Api
   `
5. Endpoints:
   - Saúde: `GET /health`
   - CRUD clientes: `GET/POST/PUT/DELETE /api/clientes`
   - Autenticação (exemplo): `POST /api/auth/token` (gera token dev)

## Executar com Docker
`bash
docker compose up --build
`
- API em: http://localhost:8080
- Postgres em: localhost:5432 (db: `clientes_db`, user: `postgres`, pass: `postgres`)

Rodar migrations dentro do contêiner (opcional):
`bash
docker compose exec api dotnet ef database update --project /app/src/Infrastructure --startup-project /app/src/Api
`

## Testes
`bash
dotnet test
`

## JWT (desenvolvimento)
- Issuer: `Clientes.Api`
- Audience: `Clientes.Audience`
- Chave (dev): `dev-super-secret-key-please-change`

> Em produção, use secrets/variáveis de ambiente para a chave JWT e connection string.
