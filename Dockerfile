FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DockerApp/DockerApp.csproj", "DockerApp/"]
RUN dotnet restore "DockerApp/DockerApp.csproj"
COPY . .
WORKDIR "/src/DockerApp"
RUN dotnet build "DockerApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerApp.dll"]