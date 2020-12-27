# Get .NET 5 SDK
FROM mcr.microsoft.com/dotnet/sdk AS build-env
# Set working directory(Linux environment)
WORKDIR /app

# Copy project file to working directory
COPY *.csproj ./
# Restore packages
RUN dotnet restore

# Copy all(excluding .dockerignore) the files to home directory
COPY . ./
RUN dotnet publish -c Release -o out

# Get runtime. Loading SDK is inefficient.
FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
EXPOSE 80

# Multipart build. Which means combining build from the previous steps and putting it into our working directory
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "WebApp.dll" ]