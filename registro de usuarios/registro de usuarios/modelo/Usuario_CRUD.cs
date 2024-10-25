using CRUD.bd;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace registro_de_usuarios.modelo
{
    public class Usuario_CRUD
    {

        private class_conexion conexion;

        public Usuario_CRUD()
        {
            conexion = new class_conexion();
        }


        public bool Agregar_producto(Usuario objeto)
        {
            try
            {   
                conexion.OpenConnection();


                string query = "INSERT INTO [sistema_parqueo].[dbo].[Usuario] " +
            "([cedula],[nombre],[email],[passw0rd],[telefono],[numeroPlaca],[fechaNacimiento])" +
            "VALUES (@Cedula, @nombre, @Email, @Password, @telefono, @numeroplaca, @fechaNacimiento)";



                using (SqlCommand command = new SqlCommand(query, conexion.Connection))
                {   
                    command.Parameters.AddWithValue("@Cedula", objeto.NumeroCedula);
                    command.Parameters.AddWithValue("@nombre", objeto.NombreCompleto);
                    command.Parameters.AddWithValue("@Email", objeto.Correo);
                    command.Parameters.AddWithValue("@Password", objeto.Contrasena);
                    command.Parameters.AddWithValue("@telefono", objeto.Telefono);
                    command.Parameters.AddWithValue("@numeroplaca", objeto.PlacaAuto);
                    command.Parameters.AddWithValue("@fechaNacimiento", objeto.FechaNacimiento);
                   




                    command.ExecuteNonQuery();

                   
                    conexion.CloseConnection();
                }

               
                return true;
            }
            catch (Exception ex)
            {  
                MessageBox.Show($"Atención: \n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public bool LoginUsuario(string Email, string password)
        {

            try
            {

                conexion.OpenConnection();

                string query = "SELECT COUNT(*) FROM [sistema_parqueo].[dbo].[Usuario] WHERE [email] = @email AND [passw0rd] = @Password";

                if (conexion.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, conexion.Connection))
                    {
                        command.Parameters.AddWithValue("@email", Email);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo abrir la conexión a la base de datos.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar: " + ex.Message);
                return false;
            }
            finally
            {
                conexion.CloseConnection();
            }
        }
        //------------------------------------------------------------ Método para mostrar todos los datos de usuarios
        /* public DataTable ObtenerTodosproductos()
         {
             try
             {
                 // Abrimos la conexión
                 conexion.OpenConnection();

                 // Creamos la consulta SQL para obtener todos los usuarios
                 string query = "SELECT " +
                                "id_art, nombre_art, stock_art, precio_art, categoria_art, descripcion" +
                                "FROM DB_Tienda_Deportiva.dbo.tb_productos";

                 // Creamos el comando con la consulta y la conexión
                 using (SqlCommand command = new SqlCommand(query, conexion.Connection))
                 {
                     // Creamos un adaptador de datos para obtener los resultados de la consulta
                     using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                     {
                         // Creamos un DataTable para almacenar los datos
                         DataTable dataTable = new DataTable();

                         // Llenamos el DataTable con los datos del adaptador
                         adapter.Fill(dataTable);

                         // Cerramos la conexión
                         conexion.CloseConnection();

                         // Retornamos el DataTable con los datos de los usuarios
                         return dataTable;
                     }
                 }
             }
             catch (Exception ex)
             {
                 // En caso de error, mostramos el mensaje en un cuadro de diálogo MessageBox
                 Console.WriteLine("Error: " + ex.Message);
                 MessageBox.Show("Atención: " + ex.Message);
                 return null;
             }
         }
         //------------------------------------------------------------ Método para eliminar usuarios
         public bool EliminarUsuarios(Usuario producto)
         {
             try
             {
                 // Abrimos la conexión
                 conexion.OpenConnection();

                 // SQL para eliminar el usuario
                 string query = "DELETE FROM DB_Tienda_Deportiva.dbo.tb_productos WHERE id_art = @Identificacion";

                 using (SqlCommand command = new SqlCommand(query, conexion.Connection))
                 {   // Asegúrate de usar la propiedad correcta de usuario que contiene el ID
                     command.Parameters.AddWithValue("@Identificacion", producto.Id_art);
                     int rowsAffected = command.ExecuteNonQuery();
                     if (rowsAffected > 0)
                     {
                         return true; // La eliminación fue exitosa
                     }
                     else
                     {
                         return false; // No se eliminó ningún registro, podría indicar un problema
                     }
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Error deleting user: " + ex.Message);
                 return false; // Hubo un error durante la eliminación
             }
         }


         //------------------------------------------------------------ Método para eliminar un usuario en la base de datos
         public bool ActualizarUsuario(Usuario producto)
         {
             try
             {   // Abrimos la conexión
                 conexion.OpenConnection();
                 // Creamos la consulta SQL para actualizar el valor del usuario
                 string query = "UPDATE DB_Tienda_Deportiva.dbo.tb_productos " +
                                "SET Id_art = @Identificacion, nombre_art = @nombre " +
                                "    Stock_art = @stock, Precio_art = @precio ," +
                                "    Categoria_art = @categoria , Descripcion_art =@descripcion, ";


                 // Creamos el comando con la consulta y la conexión
                 using (SqlCommand command = new SqlCommand(query, conexion.Connection))
                 {   // Agregamos los parámetros a la consulta


                     command.Parameters.AddWithValue("@Identificacion", producto.Id_art);
                     command.Parameters.AddWithValue("@Nombre", producto.Nom_art);
                     command.Parameters.AddWithValue("@stock", producto.Stock_art);
                     command.Parameters.AddWithValue("@precio", producto.Precio_art);
                     command.Parameters.AddWithValue("@categoria", producto.Categoria_art);
                     command.Parameters.AddWithValue("@descripcion", producto.Descripcion_art);


                     // Ejecutamos la consulta para actualizar el valor del usuario en la base de datos
                     int rowsAffected = command.ExecuteNonQuery();
                     if (rowsAffected > 0)
                     {
                         return true; // La eliminación fue exitosa
                     }
                     else
                     {
                         return false; // No se eliminó ningún registro, podría indicar un problema
                     }
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Error: " + ex.Message);
                 MessageBox.Show("Atención: " + ex.Message);
                 return false; // Hubo un error durante la eliminación
             }
         }
         //------------------------------------------------------------ Método para mostrar solo un usuario
         public DataTable ObtenerUnUsuario(String id_arts)
         {
             try
             {
                 // Abrimos la conexión
                 conexion.OpenConnection();

                 // Creamos la consulta SQL para obtener todos los usuarios
                 string query = "SELECT " +
                                "id_art, nombre_art, stock_art, precio_art, categoria_art, descripcion" +
                                "FROM DB_Tienda_Deportiva.dbo.tb_productos WHERE id_art = @Identificacion";


                 // Creamos el comando con la consulta y la conexión
                 using (SqlCommand command = new SqlCommand(query, conexion.Connection))
                 {   // Agregamos los parámetros a la consulta
                     command.Parameters.AddWithValue("@Identificacion", id_arts);
                     // Creamos un adaptador de datos para obtener los resultados de la consulta
                     using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                     {
                         // Creamos un DataTable para almacenar los datos
                         DataTable dataTable = new DataTable();

                         // Llenamos el DataTable con los datos del adaptador
                         adapter.Fill(dataTable);

                         // Cerramos la conexión
                         conexion.CloseConnection();

                         // Retornamos el DataTable con los datos de los usuarios
                         return dataTable;
                     }
                 }
             }
             catch (Exception ex)
             {
                 // En caso de error, mostramos el mensaje en un cuadro de diálogo MessageBox
                 Console.WriteLine("Error: " + ex.Message);
                 MessageBox.Show("Atención: " + ex.Message);
                 return null;
             }
         } */

    }
}
