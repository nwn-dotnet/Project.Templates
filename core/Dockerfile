# Pull Dotnet image to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Build
ADD ./src .
RUN dotnet publish -c Release

# Build the final NWN server image
FROM nwnxee/unified:2450a81
COPY --from=build /Build/bin/Release/net5.0/publish /nwn/data/data/
