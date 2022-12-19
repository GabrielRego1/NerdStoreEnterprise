#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Services/NSE.Pedido.WebAPI/NSE.Pedido.WebAPI.csproj", "src/Services/NSE.Pedido.WebAPI/"]
RUN dotnet restore "src/Services/NSE.Pedido.WebAPI/NSE.Pedido.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/NSE.Pedido.WebAPI"
RUN dotnet build "NSE.Pedido.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Pedido.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Pedido.WebAPI.dll"]