FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443
ENV ASPNETCORE_URLS http://+:8080
ENV ASPNETCORE_HTTP_PORTS=8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR "/EXOPEK_Backend"
COPY ["./EXOPEK_Backend.csproj", "./"]
RUN dotnet restore "EXOPEK_Backend.csproj"
COPY . .
WORKDIR "/EXOPEK_Backend"
RUN dotnet build "EXOPEK_Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EXOPEK_Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EXOPEK_Backend.dll"]
