FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG UID
ARG GID

RUN addgroup --gid $GID nonroot && \
    adduser --uid $UID --gid $GID --disabled-password --gecos "" nonroot && \
    echo 'nonroot ALL=(ALL) NOPASSWD: ALL' >> /etc/sudoers

USER nonroot

WORKDIR /home/nonroot/app

# Install dotnet-ef to create and run migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/home/nonroot/.dotnet/tools"

COPY --chown=nonroot:nonroot . /home/nonroot/app
RUN chmod -R 755 /home/nonroot/app

CMD ["dotnet", "watch","run", "--project" , "src/Backend.Api/Backend.Api.csproj", "--urls", "http://*:80"]

