FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Services.CustomerService.TestCases/Services.CustomerService.TestCases.csproj Services.CustomerService.TestCases/
RUN dotnet restore Services.CustomerService.TestCases/Services.CustomerService.TestCases.csproj
COPY . .
WORKDIR /src/Services.CustomerService.TestCases
RUN dotnet build Services.CustomerService.TestCases.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Services.CustomerService.TestCases.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Services.CustomerService.TestCases.dll"]
