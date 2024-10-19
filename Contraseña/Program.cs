using System;
using System.Collections.Generic;

namespace Contraseña
{
    public class persona
    {
        public string Usuario { get; set; }
        public string contrasena { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista de objetos de tipo 'persona'
            List<persona> listaPersonas = new List<persona>
            {
                new persona { Usuario = "usuario1", contrasena = "password1" },
                new persona { Usuario = "usuario2", contrasena = "password2" },
                new persona { Usuario = "usuario3", contrasena = "password3" }
            };

            bool salir = false; // Variable para controlar la salida del programa

            // Bucle principal del programa
            while (!salir)
            {
                // Mostrar menú o mensaje de bienvenida
                Console.WriteLine("\n--- Sistema de Login ---");
                Console.WriteLine("1. Iniciar sesión");
                Console.WriteLine("2. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Llamar al método Login
                        if (Login(listaPersonas))
                        {
                            Console.WriteLine("Se ha logeado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Usuario o contraseña incorrectos.");
                        }
                        break;

                    case "2":
                        // Salir del programa
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        // Método para pedir usuario y contraseña y validarlos en la lista
        static bool Login(List<persona> listaPersonas)
        {
            // Pedir al usuario el nombre de usuario y la contraseña
            Console.Write("Ingrese su nombre de usuario: ");
            string usuarioInput = Console.ReadLine();

            Console.Write("Ingrese su contraseña: ");
            string contrasenaInput = Console.ReadLine();

            // Verificar si existe una persona con el usuario y la contraseña ingresados
            foreach (var persona in listaPersonas)
            {
                if (persona.Usuario == usuarioInput && persona.contrasena == contrasenaInput)
                {
                    // Si la contraseña es "password1", se solicita cambiarla
                    if (persona.contrasena == "password1")
                    {
                        Console.WriteLine("Su contraseña es 'password1' y debe cambiarla.");
                        Console.Write("Ingrese una nueva contraseña: ");
                        string nuevaContrasena = Console.ReadLine();

                        // Verificar que la nueva contraseña sea diferente de "password1"
                        while (nuevaContrasena == "password1")
                        {
                            Console.WriteLine("La nueva contraseña no puede ser 'password1'. Intente de nuevo.");
                            Console.Write("Ingrese una nueva contraseña: ");
                            nuevaContrasena = Console.ReadLine();
                        }

                        // Asignar la nueva contraseña
                        persona.contrasena = nuevaContrasena;
                        Console.WriteLine("Contraseña cambiada correctamente.");
                    }

                    return true;  // Si coincide, se devuelve true (login exitoso)
                }
            }
            return false;  // Si no coincide, se devuelve false (fallo en el login)
        }
    }
}
