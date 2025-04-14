# caja-morelia-api
Ejercicio 2: API en .NET Core con Entity Framework

---

## Tecnologías usadas

- .NET
- Entity Framework Core
- SQLite
- Arquitectura Hexagonal
- Validaciones con Data Annotations
- Autenticación con API KEY vía Middleware

---

## Base de datos

- Se incluye una base de datos
- Gnerar nueva base de datos (opcional)
```bash
dotnet ef database drop --force --yes
dotnet ef database update
```
---

### 1. Clona el repositorio

```bash
git clone https://github.com/a1140252x/caja-morelia-api.git
cd caja-morelia-api
```

---

## 2. Cómo ejecutar el proyecto
```bash
dotnet run
```

---

## 3. Documentación
Este proyecto está estructurado siguiendo el patrón de arquitectura hexagonal.
Separando las reglas de negocio, la infraestructura y las interfaces de entrada salida, facilitando el mantenimiento, escalabilidad y pruebas.


Dominio. La capa dominio incluye 2 subcarpetas para almacenar las Entidades y los contratos (Interfaces) que deberán ser implementados

Domain/
│
├── Entities/
│   └── Cliente.cs
│
└── Interfaces/
    └── IClienteRepository.cs


Aplicación. La capa de Aplicación son los casos de uso del sistema. Contiene las reglas de aplicación que describen lo que el sistema debe hacer en respuesta a acciones del usuario o eventos del sistema.
Recibe peticiones desde los controladores (capa de entrada) en la API.
Utiliza las interfaces del dominio (IClienteRepository) para acceder a la base de datos.

Application/
└── Services/
    ├── CrearClienteService.cs
    ├── ActualizarClienteService.cs
    ├── EliminarClienteService.cs
    ├── ObtenerClienteService.cs
    └── ObtenerClientePorIdService.cs

Infrastructure. La capa de Infrastructure contiene las implementaciones concretas de las interfaces definidas en el dominio (IClienteRepository). Los repositorios implementan las interfaces del dominio y se comunican directamente con la base de datos usando Entity Framework Core. Recibe llamadas desde los servicios de aplicación.

Infrastructure/
└── Repositories/
    └── ClienteRepository.cs


Middleware. El middleware permite interceptar peticiones HTTP antes de que lleguen al controlador. En este caso, se utiliza para verificar una API Key como medida de seguridad.

Middleware/
└── ApiKeyMiddleware.cs


Controladores. El controlador ClientesController actua como adaptador para la capa de aplicación, es el encargado de manejar las solicitudes HTTP y delegar la lógica del negocio a los servicios de aplicación
Resumen de Interacción
- El ClienteController recibe las peticiones HTTP (POST, GET, PUT, DELETE).
- Llama a los Servicios de Aplicación (CrearClienteService, ActualizarClienteService, etc.).
- Los Repositorios (definidos en la capa de Infraestructura) manejan el acceso a los datos.
- Los resultados de las operaciones son devueltos a los controladores, los cuales responden al cliente con códigos HTTP adecuados (201 Created, 200 OK, 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found, etc.)

Controllers/
└── ClientesController.cs


## 4. Ejemplos de Uso del CRUD de Clientes

Obtener todos los clientes
GET /api/clientes
```bash
curl -X GET http://localhost:5000/api/clientes \
  -H "Content-Type: application/json" \
  -H "x-api-key: API_KEY"
```

Obtener un cliente por ID
GET /api/clientes/{id}
```bash
curl -X GET http://localhost:5000/api/clientes/1 \
  -H "Content-Type: application/json" \
  -H "x-api-key: API_KEY"
```

Crear un nuevo cliente
POST /api/clientes
```bash
curl -X POST http://localhost:5000/api/clientes \
  -H "Content-Type: application/json" \
  -H "x-api-key: API_KEY" \
  -d '{
    "nombre": "Juan Pérez",
    "correoElectronico": "juan@example.com",
    "telefono": "5551234567"
  }'
```

Actualizar un cliente
PUT /api/clientes/{id}
```bash
curl -X PUT http://localhost:5000/api/clientes/1 \
  -H "Content-Type: application/json" \
  -H "x-api-key: API_KEY" \
  -d '{
    "id": 1,
    "nombre": "Juan Pérez Modificado",
    "correoElectronico": "juanmodificado@example.com",
    "telefono": "5557654321"
  }'
```

Eliminar un cliente
DELETE /api/clientes/{id}
```bash
curl -X DELETE http://localhost:5000/api/clientes/1 \
  -H "Content-Type: application/json" \
  -H "x-api-key: API_KEY"
```
