

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["COVID19-UpdatesWebAPI.Net6.csproj", ""]
RUN dotnet restore "./COVID19-UpdatesWebAPI.Net6.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "COVID19-UpdatesWebAPI.Net6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "COVID19-UpdatesWebAPI.Net6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "COVID19-UpdatesWebAPI.Net6.dll"]