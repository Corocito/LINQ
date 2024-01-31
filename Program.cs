using System.Linq;
//Se inicia con LINQ

//Se define la lista con los parametros
 var frutas = new string[]{"Sandia", "Banana", "Manzana", "Fresa", "Mango", "Sandia Grande", "Sandia Pequeña", "Sandia Mediana"};

//Se usa LINQ de forma declarativa con el .Where y se le pide que agregue a una lista con el .ToList() todas las palabras de la coleccion
//frutas que inicie con "Sandia"
var SandiaList = frutas.Where(p=> p.StartsWith("Sandia")).ToList();


//Al haberse convertido a una lista, se puede recorrer por ella usando el ForEach y se muestra en pantalla cada uno de los elementos de la
//lista que se encontró anteriormente con el .Where
SandiaList.ForEach(p=>Console.WriteLine(p));