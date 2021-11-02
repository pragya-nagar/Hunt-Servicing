FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["../Services.CustomerService/Services.CustomerService.csproj", "../Services.CustomerService/"]
RUN dotnet restore "../Services.CustomerService/Services.CustomerService.csproj"
COPY . .
WORKDIR "/src/../Services.CustomerService"
RUN dotnet build "Services.CustomerService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Services.CustomerService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Services.CustomerService.dll"]