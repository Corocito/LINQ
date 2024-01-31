using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;

namespace LINQ
{
    public class LinqQuery
    {
        //Se crea la lista la cual se encargará de almacenar toda la información obtenida del JSon
        //La lista recibe la información de
        private List<Book> LibrosCollection = new List<Book>();
        //Se crea el constructor para la clase
        public LinqQuery(){
            
            using(StreamReader reader = new StreamReader("book.json")){

                //Se crea la variable que almacenará toda la información de la lectura del Json
                string json = reader.ReadToEnd();
                
                //Primero se hace referencia a la colección con el this
                //Se usa la propiedad JsonSerializer.Deserialize para convertir el archivo y se le pasa la lista de Book y la variable creada json como argumento
                //Por ultimo se pasa otro argumento el cual sirve para que no tenga problemas con el CamelCase
                this.LibrosCollection = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions()
                {PropertyNameCaseInsensitive=true});
            }
        }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Se aplica un nuevo metodo el cual se encargará de devolver toda la información obtenida
        public IEnumerable<Book> TodalaColeccion(){
            return LibrosCollection;
        }

        public void ShowValues(IEnumerable<Book> libros){
            
            //Estas variables {0,1} sirven para realizar una separación en los valores que se muestran en la consola
            Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha Publicación");
            foreach(var item in libros){
                Console.WriteLine("{0,-60} {1,15} {2,15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
            }
        }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //CONDICION WHERE
        public IEnumerable<Book> LibrosDespues2000(){
           //Metodo con Extension
           //return LibrosCollection.Where(p=> p.PublishedDate.Year > 2000);

           //Metodo con Query Expression
           return from i in LibrosCollection where i.PublishedDate.Year>2000 select i; 
        }

        //RETO CONDICION WHERE
        //Retornar los libros que tengan más de 250 páginas y el título contenga las palabras "in Action"
        public IEnumerable<Book> RetoWhere(){
            //Metodo con Extensiones
            //return LibrosCollection.Where(p=>p.PageCount>250 && p.Title.Contains("in Action"));

            //Query Expression
            return from i in LibrosCollection where i.PageCount>250 && i.Title.Contains("in Action") select i;
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //CONDICIÓN ALL
        //Las condiciones ANY y ALL son BOOLEANAS
        public bool ValorEnStatus(){
            //Forma de hacerlo con WHERE
            //return from i in LibrosCollection where i.Status!=null select i;

            //Forma con ALL
            return LibrosCollection.All(p=>p.Status != string.Empty);
        }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //CONDICIÓN ANY
        public bool AlgunoPublicado2005(){
            return LibrosCollection.Any(p=>p.PublishedDate.Year==2005);
        }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //CONDICIÓN CONTAINS
        public IEnumerable<Book> ContienePython(){
            return LibrosCollection.Where(p=>p.Categories.Contains("Python"));
        }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //CONDICION ORDERBY
        public IEnumerable<Book> OrdenarJavaTitulo(){
            return LibrosCollection.Where(p=>p.Categories.Contains("Java")).OrderBy(p=>p.Title);
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //CONDICIÓN ORDERBYDESCENDING
        public IEnumerable<Book> OrderDescending(){
            return LibrosCollection.Where(p=>p.PageCount>450).OrderByDescending(p=>p.PageCount);
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR TAKE
        public IEnumerable<Book> OperadorTake(){
            return LibrosCollection.Where(p=>p.Categories.Contains("Java")).OrderByDescending(p=>p.PublishedDate).Take(3);
        }
        
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR SKIP
        public IEnumerable<Book> operadorSkip(){
            return LibrosCollection.Where(p=>p.PageCount>400).Skip(2).Take(2);
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR SELECT
        //Utilizanco el Operador Select selecciona el titulo y el numero de paginas de los primeros 3 libros de la colección
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //El metodo SELECT crea datos dinamicos, son datos que no son especificados por lo que se vuelve dificil de manejar, es mejor crear el objeto deseado, en este
        //caso, un objeto
        public IEnumerable<Book> operadorSelect(){
            return LibrosCollection.Take(3)
            .Select(p=> new Book
            {Title = p.Title, 
            PageCount = p.PageCount});
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR COUNT 
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Utilizando el operador Count, retornar el número de libros qe tengan entre 200 y 500 páginas

        //El operador count es un contador que aumenta con cada variable que cumple con la condicion, por lo que el tipo de valor es INT 
        public int operadorCount(){
            return LibrosCollection.Count(p=>p.PageCount<=500 && p.PageCount>=200);

            //Tambien puede ser otra forma de hacerlo, aplicando el metodo Where
            //return LibrosCollection.Where(p=>p.PageCount<=500 && p.PageCount>=200).Count();
        }
    }
}