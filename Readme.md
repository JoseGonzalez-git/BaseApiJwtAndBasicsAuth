# BaseApiJwtAndBasicsAuth

Una API desarrollada en .NET 8.0 que implementa autenticación mediante JSON Web Token (JWT) y autenticación básica. Este proyecto incluye ejemplos de endpoints protegidos por ambos métodos de autenticación.

## Tabla de Contenidos
- [Requisitos](#requisitos)
- [Instalación](#instalación)
- [Configuración](#configuración)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Endpoints](#endpoints)
- [Ejemplos de Uso](#ejemplos-de-uso)

## Requisitos
- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- Configuración de variables de entorno para las credenciales JWT y autenticación básica.

## Instalación
1. Clona el repositorio:
   ```bash
   git clone <URL_DEL_REPOSITORIO>
   ```
2. Navega al directorio del proyecto:
   ```bash
   cd BaseApiJwtAndBasicsAuth
   ```
3. Restaura los paquetes NuGet:
   ```bash
   dotnet restore
   ```

## Configuración
El proyecto requiere configuración para los valores de autenticación JWT y las credenciales básicas. Puedes configurar estos valores en el archivo `appsettings.json` o como variables de entorno:

```json
{
  "Jwt": {
    "Key": "clave-secreta",
    "Issuer": "tu-issuer",
    "Audience": "tu-audience"
  },
  "BasicCredential": {
    "Username": "usuario",
    "Password": "contraseña"
  }
}
```

## Estructura del Proyecto
- **Program.cs**: Configuración inicial de la autenticación y servicios.
- **BasicAuthenticationHandler.cs**: Implementación del autenticador básico.
- **AuthController.cs**: Controlador para la generación de tokens JWT.
- **SecureController.cs**: Controlador con endpoints protegidos por JWT y autenticación básica.
- **UserCredentials.cs**: Modelo que representa las credenciales de usuario.

## Endpoints

### Autenticación
#### `POST /Auth/token`
Genera un token JWT para el usuario que provee credenciales válidas.

- **Body (JSON)**:
  ```json
  {
    "username": "usuario",
    "password": "contraseña"
  }
  ```
- **Respuesta**: Retorna un token JWT si las credenciales son válidas.

### Endpoints Seguros
#### `GET /Secure/jwt`
Endpoint protegido por autenticación JWT.

- **Autenticación**: Añade el token JWT en el header `Authorization: Bearer <token>`.

#### `GET /Secure/basic`
Endpoint protegido por autenticación básica.

- **Autenticación**: Añade el header `Authorization: Basic <credenciales_en_base64>`.

## Ejemplos de Uso

### Generar un Token JWT
```bash
curl -X POST "http://localhost:port/Auth/token" -H "Content-Type: application/json" -d '{"username":"usuario","password":"contraseña"}'
```

### Acceder a un Endpoint Protegido con JWT
```bash
curl -X GET "http://localhost:port/Secure/jwt" -H "Authorization: Bearer <token_jwt>"
```

### Acceder a un Endpoint Protegido con Autenticación Básica
```bash
curl -X GET "http://localhost:port/Secure/basic" -H "Authorization: Basic <credenciales_en_base64>"
```

## Notas Adicionales
- La autenticación básica se maneja a través de `BasicAuthenticationHandler.cs`, que valida las credenciales en el encabezado de autorización.
- Swagger se habilita en el entorno de desarrollo, permitiendo visualizar y probar los endpoints de forma interactiva.

