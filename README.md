# Unique Book Case

Para execução do projeto é necessário realizar os seguintes passos:

## Instalação

Criar um container do SQL Server:

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Dockersql123#' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu
```
Criar um container do RabbitMQ:

```bash
docker run -d -p 15672:15672 -p 5672:5672 -p 5671:5671 --hostname my-rabbitmq --name my-rabbitmq-container -e RABBITMQ_DEFAULT_USER=rabbitmq -e RABBITMQ_DEFAULT_PASS=Rabbitmq2019! rabbitmq:3-management
```

Rodar um container do Redis:

```bash
docker run --name my-redis -p 6379:6379 --restart always --detach redis
```

## Scripts para criação do banco de dados

Após a execução do procedimento acima, é preciso executar o scripts localizados na pasta "_Sql", os mesmos irão criar as tabelas do modelo de domínio e as tabelas referentes ao Identity, além de criar um usuário de teste para que os testes consigam realizar o login, recuperar o Token e executarem. 
* Porém também foi implementado o método para cadastrar um novo usuário caso seja preciso.

## O que foi implementado?

- DDD
- CQRS
- Entity Framework Core
- SQL Server
- RabbitMQ
- Redis
- Testes
- Logger
- Autenticação no sistema com Identity com JWT
- Swagger
