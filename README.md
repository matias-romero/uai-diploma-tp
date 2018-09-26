# uai-diploma-tp
SaludAr - Gestión de turnos electrónicos

Este proyecto fue presentado para el final de la materia **T109 29 - TRABAJO DE DIPLOMA** de la carrera Ing. en Sistemas Informáticos de la Universidad Abierta Interamericana.

El mismo plantea un negocio ficticio de una empresa que brinda diversos servicios médicos ambulatorios a sus pacientes, quienes en su mayoría residen en la Ciudad Autónoma de Buenos
Aires o en partidos del Gran Buenos Aires. Los mismos pueden concurrir a cualquiera de los centros de salud distribuidos en la región, generando la necesidad de tener una historia clinica centralizada entre los diferentes centros.

Entre las restricciones impuestas por la cátedra tenemos:
* Aplicación del tipo Windows Forms
* Utilizar una base de datos SQL Server con su esquema alcanzando la [3FN](https://en.wikipedia.org/wiki/Third_normal_form)
* Funcionalidad de Login / Logout haciendo uso de una "Sesión" que cumpla con el patrón [Singleton](https://en.wikipedia.org/wiki/Singleton_pattern)
* Mecanismos de encriptación simétrica para el almacenado de contraseñas en la base de datos
* Soporte de UI multidioma sin utilizar las herramientas de localización provistas por el framework. 
  * El cambio de idioma debe ser en tiempo de ejecución y utilizar el patrón [Observer](https://en.wikipedia.org/wiki/Observer_pattern)
* Gestión de permisos utilizando el concepto de Familia/Patente respetando el patrón [Composite](https://en.wikipedia.org/wiki/Composite_pattern)
* Llevar una bitácora de eventos a nivel de negocio
* Implementar un modelo de "[Digitos verificadores](https://www.codeproject.com/Tips/588941/Check-Digit-Vertical-and-Horizontal)" horizontales y verticales
  * Comprobar si los datos se modificaron directo desde la base de datos, encontrando inconsistencias con el dígito verificador calculado por la app
* Separación en "capas" respetando:
  1. Capa de entidades
  2. Capa de acceso a datos
  3. Capa de lógica de negocio
  4. Capa de presentación utilizando una interfaz [MDI](https://en.wikipedia.org/wiki/Multiple_document_interface)
