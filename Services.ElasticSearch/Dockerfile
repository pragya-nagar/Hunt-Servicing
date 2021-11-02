FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Services.ElasticSearch/Services.ElasticSearch.csproj", "Services.ElasticSearch/"]
COPY ["Services.Common/Services.Common.csproj", "Services.Common/"]
RUN dotnet restore "Services.ElasticSearch/Services.ElasticSearch.csproj"
COPY . .
WORKDIR "/src/Services.ElasticSearch"
RUN dotnet build "Services.ElasticSearch.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Services.ElasticSearch.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Services.ElasticSearch.dll"]