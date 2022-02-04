#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT="Development" \
#  DefaultConnection="server=localhost;user=mysqladmin;database=gcpfinaltask;password=MySQLadmin325;port=3306" - local MySql instance
	DefaultConnection="server=127.0.0.1;user=finaltaskaccount;database=gcpfinaltask;password=;port=3306"

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GCPDev.FinalTask/GCPDev.FinalTask.csproj", "GCPDev.FinalTask/"]
RUN dotnet restore "GCPDev.FinalTask/GCPDev.FinalTask.csproj"
COPY . .
WORKDIR "/src/GCPDev.FinalTask"
RUN dotnet build "GCPDev.FinalTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GCPDev.FinalTask.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GCPDev.FinalTask.dll"]