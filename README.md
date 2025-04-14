# caja-morelia-api
Ejercicio 2: API en .NET Core con Entity Framework


# API - Arquitectura Hexagonal
API REST para gestionar clientes usando ASP.NET Core, Entity Framework Core y arquitectura hexagonal (puertos y adaptadores).

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
