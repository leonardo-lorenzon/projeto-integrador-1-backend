# Projeto Integrador I - Aplicação Backend

## Running locally

> This setup was created for linux machines.

> Make sure to complete the prerequisites before starting.

### Prerequisites

#### Required software

To run this application locally will need to have the following software applications installed:
- [docker](https://docs.docker.com/manuals/)
- [docker-compose](https://docs.docker.com/compose/)
- [dotnet-sdk-8.0](https://learn.microsoft.com/en-us/dotnet/core/install/)
- [Entity Framework Core tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

#### Database password file

Add a database password file `password.txt` inside `db` folder containing a single line with the database password.
Check connection string at `appsettings.Development.json` file for the local database password.

### Building

Start by building the multi-container services:

```shell
make build
```

### Running

After build you can run the application:

```shell
make start
```

This command will start all containers and run the backend application in [watch mode](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-watch).

The backend application will be available on port `5000`. You can access the swagger at
http://127.0.0.1:5000/swagger/index.html, or call the APIs directly using cUrl, Postman or any other tool.

The Postgres database will be available on default port `5432`. See the connection string on
`appsettings.Development.json` file.

### Migrations

With the containers running you can run the migrations to setup the local database:

```shell
make run-migrations
```

To create a new migration after a change on database models run:

```shell
make generate-migration name=< MigrationName >
```

> **Warning!** Do not change migrations that are already on `master` branch.

> **Note:** Fix migration file formatting after generation.

### Logs

You can watch the logs of the backend application running:

```shell
make logs
```

### Stop

Stop the containers with:

```shell
make stop
```

### Tests

Run all unit tests with:

```shell
make test
```

### Other commands

For the full list of commands, see [Makefile](Makefile).
