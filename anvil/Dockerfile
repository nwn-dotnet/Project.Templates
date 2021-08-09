# Pull Dotnet image to build the project
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

ADD ./src/services /Build
WORKDIR /Build/HelloWorld
RUN dotnet publish -c Release -o out

# Build the final NWN server image
FROM nwndotnet/anvil:b48cf825
COPY --from=build /Build/HelloWorld/out /nwn/anvil/Plugins/HelloWorld/
