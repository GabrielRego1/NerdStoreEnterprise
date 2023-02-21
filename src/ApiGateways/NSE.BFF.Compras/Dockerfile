#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/ApiGateways/NSE.BFF.Compras/NSE.BFF.Compras.csproj", "src/ApiGateways/NSE.BFF.Compras/"]
RUN dotnet restore "src/ApiGateways/NSE.BFF.Compras/NSE.BFF.Compras.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/NSE.BFF.Compras"
RUN dotnet build "NSE.BFF.Compras.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.BFF.Compras.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.BFF.Compras.dll"]