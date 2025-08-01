FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5134

ENV ASPNETCORE_URLS="http://+:5134"
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["AGSRTestTask.API/AGSRTestTask.API.csproj", "AGSRTestTask.API/"]
COPY ["AGSRTestTask.Application/AGSRTestTask.Application.csproj", "AGSRTestTask.Application/"]
COPY ["AGSRTestTask.Persistence/AGSRTestTask.Persistence.csproj", "AGSRTestTask.Persistence/"]

RUN dotnet restore "AGSRTestTask.API/AGSRTestTask.API.csproj"

COPY . .

WORKDIR "/src/AGSRTestTask.API"
RUN dotnet build "AGSRTestTask.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AGSRTestTask.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AGSRTestTask.API.dll"]
