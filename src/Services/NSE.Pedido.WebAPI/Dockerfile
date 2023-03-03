#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Services/NSE.Pedidos.WebAPI/NSE.Pedidos.WebAPI.csproj", "src/Services/NSE.Pedidos.WebAPI/"]
RUN dotnet restore "src/Services/NSE.Pedidos.WebAPI/NSE.Pedidos.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/NSE.Pedidos.WebAPI"
RUN dotnet build "NSE.Pedidos.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Pedidos.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Pedidos.WebAPI.dll"]