# Pull Dotnet image to build the project
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ADD ./src /Build
WORKDIR /Build
RUN dotnet publish -c Release

# Build the final NWN server image (Version: 8193.16 11/8)
FROM nwnxee/unified:ab12798
LABEL maintainer "urothis@gmail.com"
COPY --from=build /Build/bin/Release/dotnet5.0/publish /nwn/data/data/
