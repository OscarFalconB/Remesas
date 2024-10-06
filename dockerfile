# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y publicar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out --no-self-contained

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos publicados desde la etapa de construcción
COPY --from=build-env /app/out .

# Cambiar a un puerto dinámico
ENV ASPNETCORE_URLS=http://+:5000

# Ejecutar la aplicación con el nombre correcto del archivo DLL
CMD ["dotnet", "Nueva carpeta.dll"]
