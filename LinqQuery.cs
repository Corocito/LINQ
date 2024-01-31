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
    }
}