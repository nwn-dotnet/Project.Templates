# Pull Dotnet image to build the project
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
ADD ./src /Build
WORKDIR /Build
RUN dotnet publish -c Release

# Build the final NWN server image (Version: 8193.16 Date: 10/1)
FROM nwnxee/unified:c7392de
LABEL maintainer="urothis"
COPY --from=build /Build/bin/Release/netcoreapp3.1/publish /nwn/data/data/
