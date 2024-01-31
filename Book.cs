using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQ
{
    public class Book
    {
        //Se crea una clase "Book" la cual se va a utilizar para manejar la información de los libros del archivo book.json

        //Se crean cada una de las variables que se van a utilizar para el manejo y la obtencion de la información de los libros
        //El signo de interrogación al final del string se refiere a inicializar la variable en null
        public string? Tittle {get;set;}
        public int PageCount {get;set;}
        public DateTime PublishedDate {get;set;}
        public string? URL {get;set;}
        public string? ShortDescription {get;set;}
        public string? LongDescription {get;set;}
        public string? Status {get;set;}
        public string[]? Authors {get;set;}
        public string[]? Categories {get;set;}
    }
}