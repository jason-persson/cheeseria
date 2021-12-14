FROM mcr.microsoft.com/dotnet/sdk:6.0 AS dotnet_build
WORKDIR /build
COPY ["src/server/Server.csproj", "server/"]
COPY ["src/domain/Domain.csproj", "domain/"]
COPY ["src/tests/Tests.csproj", "tests/"]
RUN dotnet restore "server/Server.csproj"
RUN dotnet restore "tests/Tests.csproj"
COPY . .
WORKDIR "/build/src/server"
RUN dotnet build "Server.csproj" -c Release -o /app/build

FROM dotnet_build AS dotnet_test
WORKDIR "/build/src/tests"
RUN dotnet test "Tests.csproj"

FROM dotnet_build AS dotnet_publish
RUN dotnet publish "Server.csproj" -c Release -o /app/publish

FROM node:16.13 AS node_build
ENV NODE_ENV=production
WORKDIR /build
COPY ["src/app", "./"]
RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS dotnet_runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM dotnet_runtime AS final
WORKDIR /app
COPY --from=dotnet_publish /app/publish .
COPY --from=node_build /build/build /app/wwwroot/
ENTRYPOINT ["dotnet", "Server.dll"]