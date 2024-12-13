# RMS
Es un gestor de reservas de salas.
## Configuración
- Ejecutar el script `database.sql` en el motor SQL Server para crear la base de datos RMS y sus respectivas tablas y procedimientos almacenados
- La solución de Visual Studio está en la carpeta RMS, con el nombre RMS.sln, es la solución que se debe ejecutar.
## Contenido
### Business
Es la capa de negocio que contiene la lógica CRUD y validación de dominio para el sistema de reservación
### Data
Es la capa de acceso a datos que contiene la conexión a base de datos, usando Dapper como ORM y el patrón repositorio para ejecutar consultas en SQL Server.
### RMS
Es el proyecto web que contiene el sitio web del sistema de gestión de reservas.

---
El archivo `test_data.sql` contiene datos de prueba para que las vistas reflejen los datos.

No está completo el proyecto y las inserciones y ediciones no funcionan, ni las busquedas.