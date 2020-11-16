using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfTurismo.Controlador;

namespace WpfTurismo
{
    /// <summary>
    /// Lógica de interacción para login.xaml
    /// </summary>
    public partial class login : Window
    {
        public static Token token { get; set; }
        public login()
        {
            InitializeComponent();
        }

        public async void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            token = new Token();
            MainWindow vprincipal = new MainWindow();
            Usuario usuario = new Usuario();
            
            string direcip = Conexion.ObtenerIpAdrees();

            usuario.email = txbCorreo.Text;
            usuario.pass = psbContraseña.Password;
            usuario.device_name = Environment.MachineName;
            usuario.ip_adress = direcip;

            token.token = Conexion.MandarCredenciales(usuario);

            if (token.token is string)
            {
                if (await Conexion.TipoDeUsuario(token) == "Administrador")
                {
                    App.Current.MainWindow.Close();
                    vprincipal.Show();
                }
                else
                {
                    MessageBox.Show("No eres administrador para iniciar la sesion");
                }
            }
            else
            {
                MessageBox.Show(token.token.StatusDescription);
            }
        }
    }
}
