#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EFCore.LazyRepository.Samples.Web/EFCore.LazyRepository.Samples.Web.csproj", "EFCore.LazyRepository.Samples.Web/"]
COPY ["EFCore.LazyRepository/EFCore.LazyRepository.csproj", "EFCore.LazyRepository/"]
COPY ["EFCore.LazyRepository.Interfaces/EFCore.LazyRepository.Interfaces.csproj", "EFCore.LazyRepository.Interfaces/"]
RUN dotnet restore "EFCore.LazyRepository.Samples.Web/EFCore.LazyRepository.Samples.Web.csproj"
COPY . .
WORKDIR "/src/EFCore.LazyRepository.Samples.Web"
RUN dotnet build "EFCore.LazyRepository.Samples.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFCore.LazyRepository.Samples.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFCore.LazyRepository.Samples.Web.dll"]
