#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Diego.MyBooks.WebApi/Diego.MyBooks.WebApi.csproj", "Diego.MyBooks.WebApi/"]
COPY ["Diego.MyBooks.Domain/Diego.MyBooks.Domain.csproj", "Diego.MyBooks.Domain/"]
COPY ["Diego.MyBooks.Infra.Data/Diego.MyBooks.Infra.Data.csproj", "Diego.MyBooks.Infra.Data/"]
RUN dotnet restore "Diego.MyBooks.WebApi/Diego.MyBooks.WebApi.csproj"
COPY . .
RUN find -type d -name bin -prune -exec rm -rf {} \; && find -type d -name obj -prune -exec rm -rf {} \;
WORKDIR "/src/Diego.MyBooks.WebApi"
RUN dotnet build "Diego.MyBooks.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Diego.MyBooks.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diego.MyBooks.WebApi.dll"]