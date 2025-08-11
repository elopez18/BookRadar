# BookRadar
Prueba Técnica – Desarrollador(a) Fullstack Semi Senior
================================================================================================================================
Pasos para ejecucion:

Prerequsitos:
Visual Studio 2022
.NET 8.0

Base de Datos: BookRadar
Microsoft SQL Server 2019


1. Abrir solucion: BookRadarBackEnd - \BookRadarBackEnd\BookRadarBackEnd.sln
2. Ajustar cadena de conexion en appsettings.json - Linea 15: "ConnectionStrings:Db:DefaultConnectionString"
3. Ajustar ruta donde queda almacenado el log - Linea 18: "FilePath"
4. Abrir SQL Server, abrir el archivo *.sql adjunto y ejecutarlo
5. Validar que se haya creado una base de datos llamada BookRadar
6. Validar que existan 2 tablas: dbo.Books, dbo.HistorialBusquedas
7. Abrir solucion: BookRadarFrontEnd - \BookRadarFrontEnd\BookRadarFrontEnd\BookRadarFrontEnd.sln
8. Iniciar BookRadarBackEnd
9. Iniciar BookRadarFrontEnd

================================================================================================================================

Decisiones de diseño:
Arquitectura:
Se decidio dividir el requerimiento en dos partes las cuales facilitan organizacion, mantenimiento y escalabilidad, ajustado a los principios SOLID
1. BookRadarBackEnd
	* Controller --> Interfaz --> Servicio --> Interfaz --> Repositorio --> Acceso a datos
2. BookRadarFrontEnd
	* Views --> Controller --> Interfaz --> Servicio --> Interfaz --> Peticiones a BookRadarBackEnd

Diseño
Manejo de framework Bootstrap  se uso por:
	* Componentes reutilizables
	* Diseño responsive
	* Código abierto y gratuito
	* Es uno de los mas usado y populares con soporte y demás

Manejo de datatables se uso por:
	* Componentes reutilizables
	* Diseño responsive
	* Código abierto y gratuito
	* Paginación de tablas
	* Opciones avanzadas de búsqueda

================================================================================================================================

Mejoras pendientes
Implementacion de seguridad, se inicio con JWt pero no se realizo una implementacion completa
Validaciones de lado de FrontEnd
