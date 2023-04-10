# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

EXPOSE 80
EXPOSE 443

WORKDIR /source
COPY . .
RUN dotnet restore "./Sender/Sender.csproj" --disable-parallel
RUN dotnet publish "./Sender/Sender.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "Sender.dll"]