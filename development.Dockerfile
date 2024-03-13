FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./Directory.Build.props ./
COPY ./Backend.sln ./
COPY ./src/Backend.Api/Backend.Api.csproj ./src/Backend.Api/Backend.Api.csproj
COPY ./src/Backend.Api/packages.lock.json ./src/Backend.Api/packages.lock.json

COPY ./src/Backend.Domain/Backend.Domain.csproj ./src/Backend.Domain/Backend.Domain.csproj
COPY ./src/Backend.Domain/packages.lock.json ./src/Backend.Domain/packages.lock.json

COPY ./src/Backend.Infrastructure/Backend.Infrastructure.csproj ./src/Backend.Infrastructure/Backend.Infrastructure.csproj
COPY ./src/Backend.Infrastructure/packages.lock.json ./src/Backend.Infrastructure/packages.lock.json

COPY ./src/Backend.UnitTest/Backend.UnitTest.csproj ./src/Backend.UnitTest/Backend.UnitTest.csproj
COPY ./src/Backend.UnitTest/packages.lock.json ./src/Backend.UnitTest/packages.lock.json

RUN dotnet restore

COPY . .

CMD ["dotnet", "watch","run", "--project" , "src/Backend.Api/Backend.Api.csproj", "--urls", "http://*:80"]
