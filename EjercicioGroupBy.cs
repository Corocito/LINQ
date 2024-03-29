using System;
using System.Collections.Generic;
using System.Linq;
using LINQ;

class EjercicioGroupBy {
  public static void Main (string[] args) {

    List<Animal> animales = new List<Animal>();
    animales.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
    animales.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
    animales.Add(new Animal() { Nombre = "Elefante", Color = "Gris" });
    animales.Add(new Animal() { Nombre = "Pantegra", Color = "Negro" });
    animales.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
    animales.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });

    // Escribe tu código aquí
    // Retorna los datos de la coleción Animales agrupada por color 
    IEnumerable<IGrouping<string, Animal>>listaAnimales = animales.GroupBy(p=>p.Color);
    
    foreach(var grupo in listaAnimales){
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60}{1,15}","Name","Color");
        foreach(var item in grupo){
            Console.WriteLine("{0,-60}{1,15}",item.Nombre,item.Color);
        }
    }
    //El archivo no es capaz de mostrar valores en pantalla debido a que no es una aplicacion de consola
  }

  public class Animal
  {
    public string Nombre {get;set;}
    public string Color {get;set;}
  }
}