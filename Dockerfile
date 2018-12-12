FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /dotnet_shared_volume
COPY . .
RUN dotnet restore -nowarn:msb3202,nu1503 -p:RestoreUseSkipNonexistentTargets=false
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "dotnet_shared_volume.csproj"]


# on container run use --add-host=inDockerHost:172.17.0.1