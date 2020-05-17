FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Microservice.ECommerce.OrderApp/Microservice.ECommerce.OrderApp.csproj", "Microservice.ECommerce.OrderApp/"]
RUN dotnet restore "Microservice.ECommerce.OrderApp/Microservice.ECommerce.OrderApp.csproj"
COPY . .
WORKDIR "/src/Microservice.ECommerce.OrderApp"
RUN dotnet build "Microservice.ECommerce.OrderApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.ECommerce.OrderApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.ECommerce.OrderApp.dll"]