# Pull Dotnet image to build the project
FROM mcr.microsoft.com/dotnet/core/sdk:3.1.102 AS build
ADD ./src /Build
WORKDIR /Build
RUN dotnet publish -c Release

# Build the final NWN server image (Version: 8193.12)
FROM nwnxee/unified:c64661b
LABEL maintainer="urothis"
COPY --from=build /Build/bin/Release/netcoreapp3.1/publish /nwn/data/data/
