FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY RulesEngine/RulesEngine.csproj RulesEngine/
COPY C:\Quartic\RulesEngine\RulesEngine\nuget.config RulesEngine/
RUN dotnet restore RulesEngine/RulesEngine.csproj
COPY . .
WORKDIR /src/RulesEngine
RUN dotnet build RulesEngine.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish RulesEngine.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RulesEngine.dll"]
