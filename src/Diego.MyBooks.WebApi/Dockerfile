#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Diego.MyBooks.WebApi/Diego.MyBooks.WebApi.csproj", "src/Diego.MyBooks.WebApi/"]
COPY ["src/Diego.MyBooks.Domain/Diego.MyBooks.Domain.csproj", "src/Diego.MyBooks.Domain/"]
COPY ["src/Diego.MyBooks.Infra.Data/Diego.MyBooks.Infra.Data.csproj", "src/Diego.MyBooks.Infra.Data/"]
RUN dotnet restore "src/Diego.MyBooks.WebApi/Diego.MyBooks.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Diego.MyBooks.WebApi"
RUN dotnet build "Diego.MyBooks.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Diego.MyBooks.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diego.MyBooks.WebApi.dll"]