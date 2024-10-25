using registro_de_usuarios.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace registro_de_usuarios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Usuario_CRUD usuarios = new Usuario_CRUD();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cedula = txtCedula.Text;
            string nombre = txtNombre.Text; 
            string correo = txtCorreo.Text;
            string password = txtContrasena.Text;
            string telefono = txtTelefono.Text;
            string numeroplaca = txtPlaca.Text;
            string rol = "Estudiante";
            DateTime fechanac = dpFechaNacimiento.DisplayDate;

            if (string.IsNullOrWhiteSpace(cedula) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(telefono) ||
                string.IsNullOrWhiteSpace(numeroplaca) ||
                string.IsNullOrWhiteSpace(rol) ||
                fechanac == DateTime.MinValue)
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Crear instancia de la clase
            Usuario objproductos = new Usuario(nombre, cedula, correo, password, fechanac, numeroplaca, telefono );

            // Agregar producto
            usuarios.Agregar_producto(objproductos);

            MessageBox.Show("producto agregado correctamente!!");

            //string query = "INSERT INTO [sistema_parqueo].[dbo].[Usuario] " +
            //                    "([cedula],[nombre],[email],[passw0rd],[telefono],[numeroPlaca],[fechaNacimiento],[rol])" +
            //                    "VALUES (@Cedula, @nombre, @Email, @Password, @telefono,@numeroplaca, @fechaNacimiento, @rol";
        }
    }
}
