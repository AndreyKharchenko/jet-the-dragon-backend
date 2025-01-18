#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ES.WebApi/ES.WebApi.csproj", "ES.WebApi/"]
COPY ["ES.Application/ES.Application.csproj", "ES.Application/"]
COPY ["ES.Domain/ES.Domain.csproj", "ES.Domain/"]
COPY ["ES.Persistence/ES.Persistence.csproj", "ES.Persistence/"]
RUN dotnet restore "ES.WebApi/ES.WebApi.csproj"
COPY . .
WORKDIR "/src/ES.WebApi"
RUN dotnet build "ES.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ES.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ES.WebApi.dll"]