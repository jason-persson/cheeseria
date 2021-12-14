FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS dotnet_runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS dotnet_build
WORKDIR /build
COPY ["src/server/Server.csproj", "server/"]
COPY ["src/domain/Domain.csproj", "domain/"]
RUN dotnet restore "server/Server.csproj"
COPY . .
WORKDIR "/build/src/server"
RUN dotnet build "Server.csproj" -c Release -o /app/build

FROM dotnet_build AS dotnet_publish
RUN dotnet publish "Server.csproj" -c Release -o /app/publish

FROM dotnet_runtime AS final
WORKDIR /app
COPY --from=dotnet_publish /app/publish .
ENTRYPOINT ["dotnet", "server.dll"]