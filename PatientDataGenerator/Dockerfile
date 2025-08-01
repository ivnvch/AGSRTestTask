FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PatientDataGenerator/PatientDataGenerator.csproj", "PatientDataGenerator/"]
COPY ["AGSRTestTask.Application/AGSRTestTask.Application.csproj", "AGSRTestTask.Application/"]
COPY ["AGSRTestTask.Domain/AGSRTestTask.Domain.csproj", "AGSRTestTask.Domain/"]
RUN dotnet restore "PatientDataGenerator/PatientDataGenerator.csproj"
COPY . .
WORKDIR "/src/PatientDataGenerator"
RUN dotnet build "./PatientDataGenerator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PatientDataGenerator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientDataGenerator.dll"]
