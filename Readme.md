# BaseApiJwtAndBasicsAuth

Una API desarrollada en .NET 8.0 que implementa autenticaci�n mediante JSON Web Token (JWT) y autenticaci�n b�sica. Este proyecto incluye ejemplos de endpoints protegidos por ambos m�todos de autenticaci�n.

## Tabla de Contenidos
- [Requisitos](#requisitos)
- [Instalaci�n](#instalaci�n)
- [Configuraci�n](#configuraci�n)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Endpoints](#endpoints)
- [Ejemplos de Uso](#ejemplos-de-uso)

## Requisitos
- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- Configuraci�n de variables de entorno para las credenciales JWT y autenticaci�n b�sica.

## Instalaci�n
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

## Configuraci�n
El proyecto requiere configuraci�n para los valores de autenticaci�n JWT y las credenciales b�sicas. Puedes configurar estos valores en el archivo `appsettings.json` o como variables de entorno:

```json
{
  "Jwt": {
    "Key": "clave-secreta",
    "Issuer": "tu-issuer",
    "Audience": "tu-audience"
  },
  "BasicCredential": {
    "Username": "usuario",
    "Password": "contrase�a"
  }
}
```

## Estructura del Proyecto
- **Program.cs**: Configuraci�n inicial de la autenticaci�n y servicios.
- **BasicAuthenticationHandler.cs**: Implementaci�n del autenticador b�sico.
- **AuthController.cs**: Controlador para la generaci�n de tokens JWT.
- **SecureController.cs**: Controlador con endpoints protegidos por JWT y autenticaci�n b�sica.
- **UserCredentials.cs**: Modelo que representa las credenciales de usuario.

## Endpoints

### Autenticaci�n
#### `POST /Auth/token`
Genera un token JWT para el usuario que provee credenciales v�lidas.

- **Body (JSON)**:
  ```json
  {
    "username": "usuario",
    "password": "contrase�a"
  }
  ```
- **Respuesta**: Retorna un token JWT si las credenciales son v�lidas.

### Endpoints Seguros
#### `GET /Secure/jwt`
Endpoint protegido por autenticaci�n JWT.

- **Autenticaci�n**: A�ade el token JWT en el header `Authorization: Bearer <token>`.

#### `GET /Secure/basic`
Endpoint protegido por autenticaci�n b�sica.

- **Autenticaci�n**: A�ade el header `Authorization: Basic <credenciales_en_base64>`.

## Ejemplos de Uso

### Generar un Token JWT
```bash
curl -X POST "http://localhost:port/Auth/token" -H "Content-Type: application/json" -d '{"username":"usuario","password":"contrase�a"}'
```

### Acceder a un Endpoint Protegido con JWT
```bash
curl -X GET "http://localhost:port/Secure/jwt" -H "Authorization: Bearer <token_jwt>"
```

### Acceder a un Endpoint Protegido con Autenticaci�n B�sica
```bash
curl -X GET "http://localhost:port/Secure/basic" -H "Authorization: Basic <credenciales_en_base64>"
```

## Notas Adicionales
- La autenticaci�n b�sica se maneja a trav�s de `BasicAuthenticationHandler.cs`, que valida las credenciales en el encabezado de autorizaci�n.
- Swagger se habilita en el entorno de desarrollo, permitiendo visualizar y probar los endpoints de forma interactiva.

