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
// var algunoPublicado2005 = query.AlgunoPublicado2005();
// Console.WriteLine($"Algun libro fue publicado en 2005?: {algunoPublicado2005}");

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR CONDICION WHERE
// var mostrarResultados = query.LibrosDespues2000();
// query.ShowValues(mostrarResultados);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR CONDICIÓN CONTAINS
// var MostrarContains = query.ContienePython();
// query.ShowValues(MostrarContains);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR CONDICION ORDERBY
// var MostrarResultadoOrdenarJava = query.OrdenarJavaTitulo();
// query.ShowValues(MostrarResultadoOrdenarJava);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR CONDICION ORDERBYDESCENDING
// var MostrarPorPaginasDesc = query.OrderDescending();
// query.ShowValues(MostrarPorPaginasDesc);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR TAKE
// var mostrarTake = query.OperadorTake();
// query.ShowValues(mostrarTake);

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR SKIP
// var mostrarSkip = query.operadorSkip();
// query.ShowValues(mostrarSkip);
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR SELECT
// var mostrarSelect = query.operadorSelect();
// query.ShowValues(mostrarSelect);
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//MOSTRAR OPERADOR COUNT
Console.WriteLine($"Cantidad de libros que tienen entre 200 y 500 páginas: {query.operadorCount()}");