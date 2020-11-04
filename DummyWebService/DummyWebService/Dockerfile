#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

ENV DBConnection="mongodb+srv://usrDummies:1usrDummies@dummies-cluster-x9n8u.gcp.mongodb.net/test?retryWrites=true"
ENV DatabaseName="sample_dummies"

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DummyWebService/DummyWebService.csproj", "DummyWebService/"]
RUN dotnet restore "DummyWebService/DummyWebService.csproj"
COPY . .
WORKDIR "/src/DummyWebService"
RUN dotnet build "DummyWebService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DummyWebService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DummyWebService.dll"]