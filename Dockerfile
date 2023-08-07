FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY ["EXOPEK_Backend/EXOPEK_Backend.csproj", "EXOPEK_Backend/"]
RUN dotnet restore "EXOPEK_Backend/EXOPEK_Backend.csproj"
COPY . .
WORKDIR "/EXOPEK_Backend"
RUN dotnet build "EXOPEK_Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EXOPEK_Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EXOPEK_Backend.dll"]
