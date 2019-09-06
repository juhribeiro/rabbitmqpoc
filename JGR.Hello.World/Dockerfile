FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY ./*.csproj ./
RUN dotnet restore -s https://api.nuget.org/v3/index.json

COPY ./. ./
COPY ./*.json ./out/

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "JGR.Hello.World.dll"]