Sistema de gestión de empleados

Esta aplicación API RESTful permite la gestión de empleados dentro de una empresa. el sistema se encuentra contruido en .NET Core, Entity Framework y Dapper y se basa en la aquitectura MVC. Con la integración de una base de datos SQL.  

Estructura del Proyecto

La arquitectura implementada en esta solución es una arquitectura en capas basada en los principios de SOLID, DDD, CQRS y Clean Code. Cuenta con Manejo de exepciones y errores.

1. Employee.API
Este es el proyecto principal de tipo API RESTful. Aplica una arquitectura MVC (Modelo, Vista, Controlador). Contiene los EndPoints para el consumo de los diferentes servicios y cuenta con la implementación de autenticación basada en OAuth 2.0 y JWT.

2. Employee.Core
Este proyecto contiene la logica de negocio para la gestión de empleados se basa en el patron de diseño CQRS (Command Query Responsibility Segregation) contiene servicios de comandos y consultas para el sistema.

3. Employee.Data
Proyecto que se encarga del acceso a base de datos por medio de Entity framework y Dapper.

4. Employee.Tests
Este proyecto contiene las pruebas unitarias para validar la funcionalidad del sistema.

Instalación y COnfiguración
Para iniciar es necesario clonar el repositorio :
https://github.com/GinaRoncancio0821/RedArborGestionEmpleados.git

Configuración de Base de Datos 
1. En la carpeta BaseDatos que se encuentra dentro del repositorio ejecutar el Script ScriptEmployeesManagemen.sql
2. Actualizar la cadena de conexión en appsettings.json de la siguiente manera:
"ConnectionStrings": {
  "DefaultConnection": "Server=SERVIDOR;Database=BASE_DE_DATOS;User Id=USUARIO;Password=CONTRASEÑA;"
}
   CONSUMO API REST POSTMAN
Dentro del repositorio se encuentra la colleción MethodEmployee.postman_collection.json que permite la interacción con la aplicación.

 API ENDPOINTS 
 1. Login
    Endpoint: POST /api/Auth
    Descripción: Permite la autenticación de la aplicación por medio de un token.
    
 2. Obtener Empleado por ID
    Endpoint: GET /api/redarbor/Employee/{id}
		Descripción: Devuelve los detalles de un empleado específico.

3.   Obtener Empleados
    Endpoint: GET /api/redarbor/Employee
		Descripción: Devuelve la lista de los empleados.

4.  Actualizar Empleados
    Endpoint: PUT /api/redarbor/Employee/{id}
		Descripción: Permite la actualización de información de un empleado específico.

5.  Eliminar Empleados
    Endpoint: DELETE /api/redarbor/employees/{id}
		Descripción: Permite la eliminación un empleado específico.

6.  Crear Empleados
    Endpoint: POST /api/redarbor/employees/
    Body:
    {
 "CompanyId": 1,
 "CreatedOn": "2000-01-01 00:00:00",
"DeletedOn": "2000-01-01 00:00:00",
 "Email": "test1@test.test.tmp",
 "Fax": "000.000.000",
 "Name": "tester1",
 "Lastlogin": "2000-01-01 00:00:00",
 "Password": "test",
 "PortalId": 1,
 "RoleId": 1,
 "StatusId": 1,
 "Telephone": "000.000.000",
 "UpdatedOn": "2000-01-01 00:00:00",
 "Username": "test1"
 }
Descripción: Permite la creación de un empleado.

