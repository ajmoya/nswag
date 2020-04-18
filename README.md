# nswag
Labs para pruebas de concepto del framework NSwag para la generación de documentación APIs REST y automatización de clientes en .NET Core

+ info: https://github.com/RicoSuter/NSwag

Requisitos previos:
--

+ VS 2019
+ API .NET Core 3.1
+ Package NSwag.AspNetCore => para la generación de documentación de APIs
+ Package NSwag.MSBuild => para la autogeneración de clientes de APIs

Pruebas de concepto:
--
La API REST consta de dos controllers: <i>WeatherForecastController</i> y <i>OtroLimitadoController</i>. Se quiere gestionar su documentación mediante el estándar OpenAPI, con los siguiente condicionantes:

+ El generador OpenAPIDocument debe crear dos documentos diferentes: <i>doc</i> y <i>read</i>, cada uno accesibles mediante path distintas
+ La especificación del documento <i>doc</i> debe ser accesible a través del path <b>urlBase/doc/openapi.json</b>
+ La especificación del documento <i>read</i> debe ser accesible a través del path <b>urlBase/read/openapi.json</b>
+ El documento <i>read</i> no debe mostrar los endpoints del controller <i>OtroLimitadoController</i>
+ Se debe generar de manera automática (cada vez que se recompile la API) dos clientes para el documento <i>doc</i>:
  + Cliente para C#
  + Cliente para Typescript
