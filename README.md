# HogwartsApi

Api Rest simple para el hipotetico caso de las incripciones en el colegio Hogwarts
de magia y hechiceria. El proyecto utiliza el modelo de capas y el pattern repositorio
modificado, de tal forma que la mayor parte de la logica de negocio se mantenga en un unico
proyecto facilitando asi su implementacion con otras herramientas.

La solucion esta compuesta por 3 proyectos:

Core: Contiene toda la logica de negocio.

EFPersistence: Encapsula el modelo de persistencia con EnttityFramework Core. Tiene la 
principal ventaja de no necesitar implementar un repositorio por entidad, gracias a la 
interfaz IRepository y los metodos de extension definidos en en proyecto Core.

Api: Es la capa rest del proyecto, combina los proyectos anteriores para conseguir 
la funcionalidad completa.

la aplicacion utiliza un modelo de respuesta generico definido como:

    {
        success:	boolean;          // indica si hubo un error
        message?:	string;           // informacion adicional
        data?:	    Entidad;          // un unico resultado
        result?:    Entidad[];        // listado de resultados
        detail:	    {*key: string[]}; // indica los errores

    }

Las validaciones se realizan con DataAnnotations las cuales son capturadas automaticamanete
por la api y mostradas de la siguiente forma:

    {
        "type": string;             // schema utilizado
        "title": string;            // informacion generica
        "status": numeric;          // estatus http
        "traceId": string;          // identificador
        "errors": {*key: string[]}; // indica los errores
    }

El modelo de las solicitudes base es:

    {
        "name": string;
        "lastName": string;
        "identification": numeric;
        "age": numeric;
        "house": ["Gryffindor"|"Hufflepuff"|"Ravenclaw"|"Slytherin"];
    }

La app consta de un unico controlador con los 4 endpoints solicitados:


[GET] /api/v1/Enrollment/AllRecords

todos las solicitudes

[POST] /api/v1/Enrollment/RequestEntry

agregar solicitud

    body: Modelo de solicitud base

[PUT] /api/v1/Enrollment/UpdateEntry

modificar solicitud

    body: Modelo de solicitud base

[DELETE] /api/v1/Enrollment/DeleteEntry/{id}

eliminar solicitud

    param id: guid identificador de la solicitud
