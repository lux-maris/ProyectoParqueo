using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace registro_de_usuarios.modelo
{
    public class Usuario
    {
        
        public string NombreCompleto { get; set; }
        public string NumeroCedula { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
       
        public DateTime FechaNacimiento { get; set; }
        public string PlacaAuto { get; set; }
        
        public string Telefono { get; set; }

       
        public Usuario()
        {
        }

        
        public Usuario(string nombreCompleto, string numeroCedula, string correo, string contrasena, DateTime fechaNacimiento, string placaAuto,string telefono)
        {
            NombreCompleto = nombreCompleto;
            NumeroCedula = numeroCedula;
            Correo = correo;
            Contrasena = contrasena;
            FechaNacimiento = fechaNacimiento;
            PlacaAuto = placaAuto;
            Telefono = telefono;
           
        }

        
        public override string ToString()
        {
            return $"Nombre Completo: {NombreCompleto}\n" +
                   $"Número de Cédula: {NumeroCedula}\n" +
                   $"Correo: {Correo}\n" +
                   
                   $"Fecha de Nacimiento: {FechaNacimiento.ToShortDateString()}\n" +
                   $"Placa: {PlacaAuto}\n" +
                   $"telefono: {Telefono}\n"
                   ;
                    
        }
    }
}
