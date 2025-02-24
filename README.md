# aban-abm-clientes
Code challenge para Aban.

Esta solución utiliza SQL Server como DBMS y Entity Framework Core como ORM.

Instalación de la base de datos
SQL Server: Crear un login con los roles dbcreator y public. Las credenciales de este login se deben corresponder con las colocadas en la sección de connection string del archivo Api/appsettings.json.

Desde la carpeta "dex-product-crud\backend\ProductCrud\src" ejecutar los siguientes comandos para crear la migración inicial de EF Core y aplicarla en la base de datos junto con los registros de prueba de prueba:

dotnet ef migrations add InitialCreate --project Infrastructure --startup-project Api

dotnet ef database update --project Infrastructure --startup-project Api
