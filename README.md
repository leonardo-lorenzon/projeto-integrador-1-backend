# Projeto Integrador I - Aplicação Backend

## Running locally

### Prerequisites

This setup was created for linux machines.
To run this application locally will need to have the following applications installed:

- [docker](https://docs.docker.com/manuals/)
- [docker-compose](https://docs.docker.com/compose/)
- [dotnet-sdk-8.0](https://learn.microsoft.com/en-us/dotnet/core/install/)

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
