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

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR LONGCOUNT
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //El operador LongCount funciona igual al operador Count, solo que devuelve un parametro de tipo Long

        public long operadorLongCount(){
            return LibrosCollection.LongCount(p=>p.PageCount<=500 && p.PageCount>=200);
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR MIN
        //Retornar la menor fecha de publicación de la lista de libros
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public DateTime operadorMin(){
            return LibrosCollection.Min(p=>p.PublishedDate);
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR MAX
        //Retornar la cantidad de páginas del libro con mayor número de páginas en la colección

        public int operadorMax(){
            return LibrosCollection.Max(p=>p.PageCount);
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR MINBY
        //Retornar el libro que tenga la menor cantidad de páginas mayor a 0

        public Book operadorMinBy(){
            return LibrosCollection.Where(p=>p.PageCount>0).MinBy(p=>p.PageCount);
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR MAXBY
        //Retorna el libro con la fecha de publicación mas reciente
        //Se debe de definir la variable como un objeto, en este caso el objeto Book ya que es de este tipo el cual estamos trabajando
        public Book operadorMaxBy(){
            return LibrosCollection.MaxBy(p=>p.PublishedDate);
        }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR SUM
        //Retornar la suma de la cantidad de paginas de todos los libros que tengan entre 0 y 500

        public int operadorSum(){
            return LibrosCollection.Where(p=>p.PageCount<=500 && p.PageCount>=0).Sum(p=>p.PageCount);
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR AGGREGATE
        //Retornar el titulo de los libros que tienen fecha de publicacion postetior a 2015

        public string operadorAggregate(){
            return LibrosCollection.Where(p=>p.PublishedDate.Year>2015).Aggregate("",(p1, p2)=>{
                if(p1 != string.Empty)
                    p1 += " - " + p2.Title;
                
                else
                    p1+=p2.Title;
                
                return p1;
            });
        }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR AVERAGE
        //Retorna un promedio de alguna propiedad numérica
        //Retorna el promedio de caracteres que tienen los títulos de la colección
        public double opAverage(){
            
            return LibrosCollection.Average(p=>p.Title.Length);
        }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR GROUP BY
        //Retornar todos los libros que fueron publicados a partir del 2000, agrupados por año
        public IEnumerable<IGrouping<int, Book>>operadorGroupBy(){

            return LibrosCollection.Where(p=>p.PublishedDate.Year>=2000).GroupBy(p=>p.PublishedDate.Year);
        }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR LOOKUP
        //Este operador funciona como un diccionario para realizar busquedas y agrupar los datos por una propiedad
        public ILookup<char, Book> DiccionarioPorLetra(){
            return LibrosCollection.ToLookup(p=>p.Title[0]);
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //OPERADOR JOIN
        //Este operador funciona para unir la información para mostarla 
        public IEnumerable<Book> filtrarLibros(){
            var LibrosDespues2005 = LibrosCollection.Where(p=>p.PublishedDate.Year>2005);
            var LibrosMas500Pag = LibrosCollection.Where(p=>p.PageCount>500);

            return LibrosDespues2005.Join(LibrosMas500Pag, p=>p.Title, x=>x.Title, (p,x) => p);
        }

    }
}