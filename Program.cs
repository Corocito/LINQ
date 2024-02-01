using System.Linq;
using LINQ;
//Se inicia con LINQ

// //Se define la lista con los parametros
//  var frutas = new string[]{"Sandia", "Banana", "Manzana", "Fresa", "Mango", "Sandia Grande", "Sandia Pequeña", "Sandia Mediana"};

// //Se usa LINQ de forma declarativa con el .Where y se le pide que agregue a una lista con el .ToList() todas las palabras de la coleccion
// //frutas que inicie con "Sandia"
// var SandiaList = frutas.Where(p=> p.StartsWith("Sandia")).ToList();


// //Al haberse convertido a una lista, se puede recorrer por ella usando el ForEach y se muestra en pantalla cada uno de los elementos de la
// //lista que se encontró anteriormente con el .Where
// SandiaList.ForEach(p=>Console.WriteLine(p));

LinqQuery query = new LinqQuery();

//MOSTRAR CONDICION ALL
// var libros= query.ValorEnStatus();
// Console.WriteLine($"Todos los libros poseen estatus?: {libros}");
// //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
// //MOSTRAR CONDICION ANY
var algunoPublicado2005 = query.AlgunoPublicado2005();
Console.WriteLine($"Algun libro fue publicado en 2005?: {algunoPublicado2005}");

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR CONDICION WHERE
var mostrarResultados = query.LibrosDespues2000();
query.ShowValues(mostrarResultados);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR CONDICIÓN CONTAINS
var MostrarContains = query.ContienePython();
query.ShowValues(MostrarContains);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR CONDICION ORDERBY
var MostrarResultadoOrdenarJava = query.OrdenarJavaTitulo();
query.ShowValues(MostrarResultadoOrdenarJava);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR CONDICION ORDERBYDESCENDING
var MostrarPorPaginasDesc = query.OrderDescending();
query.ShowValues(MostrarPorPaginasDesc);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR TAKE
var mostrarTake = query.OperadorTake();
query.ShowValues(mostrarTake);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR SKIP
var mostrarSkip = query.operadorSkip();
query.ShowValues(mostrarSkip);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR SELECT
var mostrarSelect = query.operadorSelect();
query.ShowValues(mostrarSelect);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR COUNT
int cantidadLibrosCount = query.operadorCount();
Console.WriteLine($"Cantidad de libros que tienen entre 200 y 500 páginas es de {cantidadLibrosCount} libros");

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR LONGCOUNT
long cantidadLibrosLongCount = query.operadorLongCount();
Console.WriteLine($"La cantidad de libros que tienen entre 200 y 500 páginas es de {cantidadLibrosLongCount} libros");

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR MIN
DateTime fechaMinimaPublicacion = query.operadorMin();
Console.WriteLine($"La fecha mínima de publicación es de: {fechaMinimaPublicacion.ToShortDateString()}");   

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR MAX
int MayorCantidadPaginas = query.operadorMax();
Console.WriteLine($"La mayor cantidad de páginas es de: {MayorCantidadPaginas}");

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR MINBY
var listaLibroCondicionMinBy = query.operadorMinBy();
Console.WriteLine($"El libro con menor cantidad de páginas mayor a 0 es: {listaLibroCondicionMinBy.Title} con: {listaLibroCondicionMinBy.PageCount} páginas");

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR MAXBY
var listaMaxBy = query.operadorMaxBy();
Console.WriteLine($"El libro con fecha de publicación mas reciente es: {listaMaxBy.Title} con fecha de publicación de {listaMaxBy.PublishedDate.ToShortDateString()}");

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR SUM
var sumaPaginas = query.operadorSum();
Console.WriteLine($"La suma de las páginas de los libros entre 0 y 500 páginas es de: {sumaPaginas}");

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR AGGREGATE
var opAggregate = query.operadorAggregate();
Console.WriteLine(opAggregate);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR AVERAGE
var opAverage = query.opAverage();
Console.WriteLine($"El promedio de caracteres en los titulos de los libros es de: {opAverage}");
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR GROUP BY

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> listaLibros){
    foreach(var grupo in listaLibros){
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha Publicación");
        foreach(var item in grupo){
            Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}

var opGroupBy = query.operadorGroupBy();
ImprimirGrupo(opGroupBy);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR JOIN

var filtrarJoin= query.filtrarLibros();
query.ShowValues(filtrarJoin);
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------




