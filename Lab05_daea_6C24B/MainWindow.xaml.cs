using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab05_daea_6C24B
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connectionString = "Data Source=LAB1504-16\\SQLEXPRESS;Initial Catalog=Neptuno;User Id=admin;Password=admin";
        public List<Clientes> ListaClientes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ListaClientes = new List<Clientes>();
            dataEmpleados.ItemsSource = ListaClientes;
        }

        private void InsertarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("InsertarEmpleado", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@IdEmpleado", int.Parse(IdEmpleadoTextBox.Text));
                    command.Parameters.AddWithValue("@Apellidos", ApellidosTextBox.Text);
                    command.Parameters.AddWithValue("@Nombre", NombreTextBox.Text);
                    command.Parameters.AddWithValue("@Cargo", CargoTextBox.Text);
                    command.Parameters.AddWithValue("@Tratamiento", TratamientoTextBox.Text);
                    command.Parameters.AddWithValue("@FechaNacimiento", DateTime.Parse(FechaNacimientoTextBox.Text));
                    command.Parameters.AddWithValue("@FechaContratacion", DateTime.Parse(FechaContratacionTextBox.Text));
                    command.Parameters.AddWithValue("@Direccion", DireccionTextBox.Text);
                    command.Parameters.AddWithValue("@Ciudad", CiudadTextBox.Text);
                    command.Parameters.AddWithValue("@Region", RegionTextBox.Text);
                    command.Parameters.AddWithValue("@CodigoPostal", CodigoPostalTextBox.Text);
                    command.Parameters.AddWithValue("@Pais", PaisTextBox.Text);
                    command.Parameters.AddWithValue("@Telefono", TelefonoTextBox.Text);
                    command.Parameters.AddWithValue("@Extension", ExtensionTextBox.Text);
                    command.Parameters.AddWithValue("@Notas", NotasTextBox.Text);
                    command.Parameters.AddWithValue("@Jefe", int.Parse(JefeTextBox.Text));
                    command.Parameters.AddWithValue("@SueldoBasico", decimal.Parse(SueldoBasicoTextBox.Text));

                    // Ejecutar el comando
                    command.ExecuteNonQuery();

                    MessageBox.Show("Empleado insertado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar empleado: " + ex.Message);
            }
        }

        private void ActualizarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("ActualizarEmpleado", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@IdEmpleado", int.Parse(IdEmpleadoTextBox.Text));
                    command.Parameters.AddWithValue("@Apellidos", ApellidosTextBox.Text);
                    command.Parameters.AddWithValue("@Nombre", NombreTextBox.Text);
                    command.Parameters.AddWithValue("@Cargo", CargoTextBox.Text);
                    command.Parameters.AddWithValue("@Tratamiento", TratamientoTextBox.Text);
                    command.Parameters.AddWithValue("@FechaNacimiento", DateTime.Parse(FechaNacimientoTextBox.Text));
                    command.Parameters.AddWithValue("@FechaContratacion", DateTime.Parse(FechaContratacionTextBox.Text));
                    command.Parameters.AddWithValue("@Direccion", DireccionTextBox.Text);
                    command.Parameters.AddWithValue("@Ciudad", CiudadTextBox.Text);
                    command.Parameters.AddWithValue("@Region", RegionTextBox.Text);
                    command.Parameters.AddWithValue("@CodigoPostal", CodigoPostalTextBox.Text);
                    command.Parameters.AddWithValue("@Pais", PaisTextBox.Text);
                    command.Parameters.AddWithValue("@Telefono", TelefonoTextBox.Text);
                    command.Parameters.AddWithValue("@Extension", ExtensionTextBox.Text);
                    command.Parameters.AddWithValue("@Notas", NotasTextBox.Text);
                    command.Parameters.AddWithValue("@Jefe", int.Parse(JefeTextBox.Text));
                    command.Parameters.AddWithValue("@SueldoBasico", decimal.Parse(SueldoBasicoTextBox.Text));

                    // Ejecutar el comando
                    command.ExecuteNonQuery();

                    MessageBox.Show("Empleado insertado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar empleado: " + ex.Message);
            }
        }

        private void ListarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            List<Clientes> clientes = new List<Clientes>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ListarEmpleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idCliente = reader.GetInt32(reader.GetOrdinal("IdEmpleado"));
                                string nombreCompañia = reader.GetString(reader.GetOrdinal("Nombre"));
                                string nombreContacto = reader.GetString(reader.GetOrdinal("Cargo"));
                                string cargoContacto = reader.GetString(reader.GetOrdinal("Tratamiento"));
                                DateTime direccion = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento"));
                                DateTime ciudad = reader.GetDateTime(reader.GetOrdinal("FechaContratacion"));

                                clientes.Add(new Clientes(idCliente, nombreCompañia, nombreContacto, cargoContacto, direccion, ciudad));
                            }
                        }
                    }
                }

                dataEmpleados.ItemsSource = clientes;
                dataEmpleados.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}