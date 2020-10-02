#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TestAppForOpenshift/TestAppForOpenshift.csproj", "TestAppForOpenshift/"]
RUN dotnet restore "TestAppForOpenshift/TestAppForOpenshift.csproj"
COPY . .
WORKDIR "/src/TestAppForOpenshift"
RUN dotnet build "TestAppForOpenshift.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestAppForOpenshift.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestAppForOpenshift.dll"]