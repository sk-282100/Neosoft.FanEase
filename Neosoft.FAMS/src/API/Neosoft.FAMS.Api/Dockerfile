#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/API/Neosoft.FAMS.Api/Neosoft.FAMS.Api.csproj", "src/API/Neosoft.FAMS.Api/"]
COPY ["src/Infrastructure/Neosoft.FAMS.Infrastructure/Neosoft.FAMS.Infrastructure.csproj", "src/Infrastructure/Neosoft.FAMS.Infrastructure/"]
COPY ["src/Core/Neosoft.FAMS.Application/Neosoft.FAMS.Application.csproj", "src/Core/Neosoft.FAMS.Application/"]
COPY ["src/Core/Neosoft.FAMS.Domain/Neosoft.FAMS.Domain.csproj", "src/Core/Neosoft.FAMS.Domain/"]
COPY ["src/Infrastructure/Neosoft.FAMS.Identity/Neosoft.FAMS.Identity.csproj", "src/Infrastructure/Neosoft.FAMS.Identity/"]
COPY ["src/Infrastructure/Neosoft.FAMS.Persistence/Neosoft.FAMS.Persistence.csproj", "src/Infrastructure/Neosoft.FAMS.Persistence/"]
RUN dotnet restore "src/API/Neosoft.FAMS.Api/Neosoft.FAMS.Api.csproj"
COPY . .
WORKDIR "/src/src/API/Neosoft.FAMS.Api"
RUN dotnet build "Neosoft.FAMS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Neosoft.FAMS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Neosoft.FAMS.Api.dll"]
