# Use the official .NET runtime base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use .NET SDK to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["template/Function.csproj", "template/"]
RUN dotnet restore "template/Function.csproj"
COPY . .
WORKDIR "/src/template"
RUN dotnet publish "Function.csproj" -c Release -o /app/publish

# Define the runtime
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "template.dll"]
