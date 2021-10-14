#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["test/Neosoft.FAMS.API.IntegrationTests/Neosoft.FAMS.API.IntegrationTests.csproj", "test/Neosoft.FAMS.API.IntegrationTests/"]
COPY ["src/Infrastructure/Neosoft.FAMS.Persistence/Neosoft.FAMS.Persistence.csproj", "src/Infrastructure/Neosoft.FAMS.Persistence/"]
COPY ["src/Core/Neosoft.FAMS.Application/Neosoft.FAMS.Application.csproj", "src/Core/Neosoft.FAMS.Application/"]
COPY ["src/Core/Neosoft.FAMS.Domain/Neosoft.FAMS.Domain.csproj", "src/Core/Neosoft.FAMS.Domain/"]
COPY ["src/API/Neosoft.FAMS.Api/Neosoft.FAMS.Api.csproj", "src/API/Neosoft.FAMS.Api/"]
COPY ["src/Infrastructure/Neosoft.FAMS.Infrastructure/Neosoft.FAMS.Infrastructure.csproj", "src/Infrastructure/Neosoft.FAMS.Infrastructure/"]
COPY ["src/Infrastructure/Neosoft.FAMS.Identity/Neosoft.FAMS.Identity.csproj", "src/Infrastructure/Neosoft.FAMS.Identity/"]
RUN dotnet restore "test/Neosoft.FAMS.API.IntegrationTests/Neosoft.FAMS.API.IntegrationTests.csproj"
COPY . .
WORKDIR "/src/test/Neosoft.FAMS.API.IntegrationTests"
RUN dotnet build "Neosoft.FAMS.API.IntegrationTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Neosoft.FAMS.API.IntegrationTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Neosoft.FAMS.API.IntegrationTests.dll"]
