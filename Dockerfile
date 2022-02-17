#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Exam.API/Exam.API.csproj", "Exam.API/"]
COPY ["Exam.Application/Exam.Application.csproj", "Exam.Application/"]
COPY ["Exam.Repositories/Exam.Repositories.csproj", "Exam.Repositories/"]
COPY ["Exam.Domain/Exam.Domain.csproj", "Exam.Domain/"]
RUN dotnet restore "Exam.API/Exam.API.csproj"
COPY . .
WORKDIR "/src/Exam.API"
RUN dotnet build "Exam.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Exam.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exam.API.dll"]