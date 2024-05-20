FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/AyatGroupTest.Web.Host/AyatGroupTest.Web.Host.csproj", "src/AyatGroupTest.Web.Host/"]
COPY ["src/AyatGroupTest.Web.Core/AyatGroupTest.Web.Core.csproj", "src/AyatGroupTest.Web.Core/"]
COPY ["src/AyatGroupTest.Application/AyatGroupTest.Application.csproj", "src/AyatGroupTest.Application/"]
COPY ["src/AyatGroupTest.Core/AyatGroupTest.Core.csproj", "src/AyatGroupTest.Core/"]
COPY ["src/AyatGroupTest.EntityFrameworkCore/AyatGroupTest.EntityFrameworkCore.csproj", "src/AyatGroupTest.EntityFrameworkCore/"]
WORKDIR "/src/src/AyatGroupTest.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/AyatGroupTest.Web.Host", "src/AyatGroupTest.Web.Host"]
COPY ["src/AyatGroupTest.Web.Core", "src/AyatGroupTest.Web.Core"]
COPY ["src/AyatGroupTest.Application", "src/AyatGroupTest.Application"]
COPY ["src/AyatGroupTest.Core", "src/AyatGroupTest.Core"]
COPY ["src/AyatGroupTest.EntityFrameworkCore", "src/AyatGroupTest.EntityFrameworkCore"]
WORKDIR "/src/src/AyatGroupTest.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "AyatGroupTest.Web.Host.dll"]
