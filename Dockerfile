FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /sources

# Copy everything else and build website
COPY Sss.Umb9.Mutobo.Web/. ./Sss.Umb9.Mutobo.Web/
WORKDIR /sources/Sss.Umb9.Mutobo.Web

RUN dotnet nuget add source "https://www.myget.org/F/umbracoprereleases/api/v3/index.json" -n "Umbraco Prereleases"
RUN dotnet restore
RUN dotnet publish -c release -o /output/Sss.Umb9.Mutobo.Web --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /output/Sss.Umb9.Mutobo.Web
COPY --from=build /output/Sss.Umb9.Mutobo.Web ./
ENTRYPOINT ["dotnet", "Sss.Umb9.Mutobo.Web.dll"]

# Copy the wait-for-it.sh script as an mssql prerequisite
COPY ./wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh