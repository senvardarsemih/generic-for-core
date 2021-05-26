#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/PatternForCore.Web/PatternForCore.Web.csproj", "src/PatternForCore.Web/"]
COPY ["src/PatternForCore.Services/PatternForCore.Services.csproj", "src/PatternForCore.Services/"]
COPY ["src/PatternForCore.Core/PatternForCore.Core.csproj", "src/PatternForCore.Core/"]
COPY ["src/PatternForCore.Models/PatternForCore.Models.csproj", "src/PatternForCore.Models/"]
RUN dotnet restore "src/PatternForCore.Web/PatternForCore.Web.csproj"
COPY . .
WORKDIR "/src/src/PatternForCore.Web"
RUN dotnet build "PatternForCore.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatternForCore.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatternForCore.Web.dll"]