FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM node:10.15-alpine AS client 
ARG skip_client_build=false 

WORKDIR /app 

COPY /Frontend . 
RUN [[ ${skip_client_build} = true ]] && echo "Skipping npm install" || npm install 
RUN [[ ${skip_client_build} = true ]] && mkdir dist || npm run-script build

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

WORKDIR /src

COPY ["PokeLexApi.csproj", "./"]

RUN dotnet restore "PokeLexApi.csproj"

COPY . .

# WORKDIR "/src/."
RUN dotnet build "PokeLexApi.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "PokeLexApi.csproj" -c Release -o /app/publish

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

COPY --from=client /app/dist /app/dist

ENTRYPOINT ["dotnet", "PokeLexApi.dll"]