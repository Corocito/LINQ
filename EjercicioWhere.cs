using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class EjercicioWhere {
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
    // filtra todos los animales que sean de color verde que su nombre inicie con una vocal
    var vocales = new string []{"A","E","I","O","U"};
    var ListaAnimales = (from p in animales where p.Color=="Verde" && vocales.Any(vocal=>p.Nombre.StartsWith(vocal)) select p);

    List<Animal> resultado = ListaAnimales.ToList();
    
    foreach(Animal a in resultado){
        Console.WriteLine(a.Nombre);
    }

    //Retorna los eleentos de la colección animal ordenados por nombre
    //SOLUCION DEL EJERCICIO DE ORDERBY
    var ListaAnimalesOrder = (from p in animales orderby p.Nombre select p);

    foreach(Animal a in ListaAnimalesOrder){
      Console.WriteLine(a.Nombre);
    }
  }
    
    
  public class Animal
  {
    public string Nombre {get;set;}
    public string Color {get;set;}
  }
}

