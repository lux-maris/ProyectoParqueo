using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;

namespace CRUD.bd
{
    public class class_conexion
    {
        
        private readonly String server; 
        private readonly String database;
        private readonly string connectionString; 
                                                  
        private SqlConnection connection; 
       
        public SqlConnection Connection
        {  
            get
            {   
                if (connection == null)
                {   
                    connection = new SqlConnection(connectionString);
                }
                return connection; 
            }
        }
        //------------------------------------------------------------------------------------- Constructor de la clase
        public class_conexion()
        {   
            this.server = "FABIAN\\MSSQLDEVELOPER";
            this.database = "DB_Tienda_Deportiva";
            connectionString = $"Server={server};Database={database}; integrated security = true; ";
        }
        public bool IsConnected => (connection != null && connection.State == System.Data.ConnectionState.Open);

        //------------------------------------------------------------------- Método para abrir la conexión con la base de datos.
        public bool OpenConnection()
        {
            try
            {
                if (!IsConnected)
                {
                    Connection.Open(); 
                }
                return true; 
            }
            catch (Exception ex)
            {

           
                MessageBox.Show("Atención: " + ex.Message); 
                return false; 
            }
        }

        //----------------------------------------------------------------- Método para cerrar la conexión con la base de datos.
        public bool CloseConnection()
        {
            try
            {
                if (IsConnected) 
                {
                    Connection.Close(); 
                }
                return true; 
            }
            catch (Exception ex)
            {   
                MessageBox.Show("Atención: " + ex.Message); 
                return false; 
            }
        }
        //---------------- Implementación del método Dispose de la interfaz IDisposable para liberar los recursos de la conexión.
        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose(); 
                connection = null; 
            }
        }
    }
}