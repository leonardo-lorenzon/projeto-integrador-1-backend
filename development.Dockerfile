FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

RUN useradd -ms /bin/sh -u 1001 dotnet
USER dotnet

# Install dotnet-ef to create and run migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/home/dotnet/.dotnet/tools"

COPY --chown=dotnet:dotnet ./Directory.Build.props ./
COPY --chown=dotnet:dotnet ./Backend.sln ./
COPY --chown=dotnet:dotnet ./src/Backend.Api/Backend.Api.csproj ./src/Backend.Api/Backend.Api.csproj
COPY --chown=dotnet:dotnet ./src/Backend.Api/packages.lock.json ./src/Backend.Api/packages.lock.json

COPY --chown=dotnet:dotnet ./src/Backend.Domain/Backend.Domain.csproj ./src/Backend.Domain/Backend.Domain.csproj
COPY --chown=dotnet:dotnet ./src/Backend.Domain/packages.lock.json ./src/Backend.Domain/packages.lock.json

COPY --chown=dotnet:dotnet ./src/Backend.Infrastructure/Backend.Infrastructure.csproj ./src/Backend.Infrastructure/Backend.Infrastructure.csproj
COPY --chown=dotnet:dotnet ./src/Backend.Infrastructure/packages.lock.json ./src/Backend.Infrastructure/packages.lock.json

COPY --chown=dotnet:dotnet ./src/Backend.UnitTest/Backend.UnitTest.csproj ./src/Backend.UnitTest/Backend.UnitTest.csproj
COPY --chown=dotnet:dotnet ./src/Backend.UnitTest/packages.lock.json ./src/Backend.UnitTest/packages.lock.json

RUN dotnet restore

COPY --chown=dotnet:dotnet . ./

CMD ["dotnet", "watch","run", "--project" , "src/Backend.Api/Backend.Api.csproj", "--urls", "http://*:80"]
