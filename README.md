# Financial Management API

API REST para gerenciamento de transações financeiras pessoais, desenvolvida com ASP.NET Core e C#.

## Tecnologias

- ASP.NET Core 9
- C#
- Entity Framework Core 9
- PostgreSQL
- Swagger / OpenAPI
- Dependency Injection
- Data Annotations (validação)
- Global Error Handling
- Structured Logging

## Funcionalidades

- Listar todas as transações
- Buscar transação por ID
- Criar nova transação (receita ou despesa)
- Validação automática de dados de entrada
- Logging estruturado
- Tratamento global de erros

## Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | /api/transactions | Lista todas as transações |
| GET | /api/transactions/{id} | Busca transação por ID |
| POST | /api/transactions | Cria nova transação |

## Exemplo de uso
```json
POST /api/transactions
{
  "description": "Supermercado",
  "amount": 250.90,
  "category": "Alimentação",
  "type": 1
}
```

`type`: 0 = Income, 1 = Expense

## Execução local

> Pré-requisito: Docker instalado e rodando.

Suba o banco de dados:
```bash
docker run --name financialdb -e POSTGRES_PASSWORD=postgres -p 5432:5432 -d postgres
```

Rode a API:
```bash
dotnet restore
dotnet ef database update
dotnet run
```

Swagger disponível em: `http://localhost:{porta}/swagger`

## Roadmap

- [x] PostgreSQL com Entity Framework Core
- [ ] Repository Pattern
- [ ] JWT Authentication
- [ ] Filtros e paginação
- [ ] Testes unitários