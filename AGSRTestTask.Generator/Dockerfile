FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AGSRTestTask.Generator/AGSRTestTask.Generator.csproj", "AGSRTestTask.Generator/"]
COPY ["AGSRTestTask.Application/AGSRTestTask.Application.csproj", "AGSRTestTask.Application/"]
COPY ["AGSRTestTask.Domain/AGSRTestTask.Domain.csproj", "AGSRTestTask.Domain/"]
RUN dotnet restore "AGSRTestTask.Generator/AGSRTestTask.Generator.csproj"
COPY . .
WORKDIR "/src/AGSRTestTask.Generator"
RUN dotnet build "./AGSRTestTask.Generator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AGSRTestTask.Generator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AGSRTestTask.Generator.dll"]
