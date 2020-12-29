# Dockerfile

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /src
COPY SurveyApp.sln ./
COPY SurveyApp.Data/*.csproj ./SurveyApp.Data/
COPY SurveyApp.Services/*.csproj ./SurveyApp.Services/
COPY SurveyApp.Web/*.csproj ./SurveyApp.Web/

RUN dotnet restore
COPY . .
WORKDIR /src/SurveyApp.Data
RUN dotnet build -c Release -o /app

WORKDIR /src/SurveyApp.Services
RUN dotnet build -c Release -o /app

WORKDIR /src/SurveyApp.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SurveyApp.Web.dll"]