FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/PatternForCore.Web/PatternForCore.Web.csproj", "src/PatternForCore.Web/"]
COPY ["src/PatternForCore.Services/PatternForCore.Services.csproj", "src/PatternForCore.Services/"]
COPY ["src/PatternForCore.Core/PatternForCore.Core.csproj", "src/PatternForCore.Core/"]
COPY ["src/PatternForCore.Models/PatternForCore.Models.csproj", "src/PatternForCore.Models/"]
RUN dotnet restore "src/PatternForCore.Web/PatternForCore.Web.csproj"
COPY . .
WORKDIR "/src/src/PatternForCore.Web"
RUN dotnet build "PatternForCore.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PatternForCore.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PatternForCore.Web.dll"]