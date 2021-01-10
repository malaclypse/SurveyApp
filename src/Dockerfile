
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
RUN apt-get install -y npm

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
RUN apt-get install -y npm

WORKDIR /src
COPY ["SurveyApp.Web/SurveyApp.Web.csproj", "SurveyApp.Web/"]
COPY ["SurveyApp.Services/SurveyApp.Services.csproj", "SurveyApp.Services/"]
COPY ["SurveyApp.Data/SurveyApp.Data.csproj", "SurveyApp.Data/"]
RUN dotnet restore "SurveyApp.Web/SurveyApp.Web.csproj"
COPY . .
WORKDIR "/src/SurveyApp.Web"
RUN dotnet build "SurveyApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SurveyApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SurveyApp.Web.dll"]