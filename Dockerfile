# Pull Dotnet image to build the project
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN apt-get update && apt-get clean && rm -rf /var/lib/apt/lists/*
ADD ./src /Build
WORKDIR /Build
RUN dotnet publish -c Release

# Build the final NWN server image (Version: 8193.16 Date: 10/1)
FROM index.docker.io/nwnxee/unified:c7392de
LABEL maintainer="urothis"
RUN apt-get update && apt-get clean && rm -rf /var/lib/apt/lists/*
COPY --from=build /Build/bin/Release/netcoreapp3.1/publish /nwn/data/data/
