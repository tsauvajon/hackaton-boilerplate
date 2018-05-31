FROM microsoft/aspnetcore-build:2.0 as build-dotnet
WORKDIR /app

COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o publish

FROM node:9.11.1-alpine as build-node
WORKDIR /app
COPY . .
RUN yarn --frozen-lockfile
RUN yarn build

FROM microsoft/aspnetcore:2.0.8
LABEL maintainer="Thomas Sauvajon <thomas.sauvajon.dev@gmail.com>"
WORKDIR /app
RUN mkdir wwwroot
COPY --from=build-dotnet /app/publish .
COPY --from=build-node /app/wwwroot wwwroot/

ENTRYPOINT ["dotnet", "Hackaton.dll"]
EXPOSE 80
