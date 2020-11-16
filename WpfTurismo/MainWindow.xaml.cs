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
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using WpfTurismo.Controlador;

namespace WpfTurismo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // Grafico de la visual dash
        public MainWindow()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2018",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "2019",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            SeriesCollection[1].Values.Add(48d);

            Labels = new[] { "Enero", "Febrero", "Marzo", "Abril" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        //Navegar por las diferentes pantallas de la aplicacion
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (210 * index),0, 0, 0);

            switch(index)
            {
                case 0:
                    GridCursor.Background = Brushes.MistyRose;
                    GridMain.Visibility = Visibility.Visible;
                    GridDepa.Visibility = Visibility.Collapsed;
                    GridArri.Visibility = Visibility.Collapsed;
                    GridAdmin.Visibility = Visibility.Collapsed;
                    GridFina.Visibility = Visibility.Collapsed;
                    GridUsuarios.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    GridCursor.Background = Brushes.YellowGreen;
                    GridMain.Visibility = Visibility.Collapsed;
                    GridDepa.Visibility = Visibility.Visible;
                    GridArri.Visibility = Visibility.Collapsed;
                    GridAdmin.Visibility = Visibility.Collapsed;
                    GridFina.Visibility = Visibility.Collapsed;
                    GridUsuarios.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    GridCursor.Background = Brushes.MistyRose;
                    GridMain.Visibility = Visibility.Collapsed;
                    GridDepa.Visibility = Visibility.Collapsed;
                    GridArri.Visibility = Visibility.Visible;
                    GridAdmin.Visibility = Visibility.Collapsed;
                    GridFina.Visibility = Visibility.Collapsed;
                    GridUsuarios.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    GridCursor.Background = Brushes.Orange;
                    GridMain.Visibility = Visibility.Collapsed;
                    GridDepa.Visibility = Visibility.Collapsed;
                    GridArri.Visibility = Visibility.Collapsed;
                    GridAdmin.Visibility = Visibility.Visible;
                    GridFina.Visibility = Visibility.Collapsed;
                    GridUsuarios.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    GridCursor.Background = Brushes.DodgerBlue;
                    GridMain.Visibility = Visibility.Collapsed;
                    GridDepa.Visibility = Visibility.Collapsed;
                    GridArri.Visibility = Visibility.Collapsed;
                    GridAdmin.Visibility = Visibility.Collapsed;
                    GridFina.Visibility = Visibility.Visible;
                    GridUsuarios.Visibility = Visibility.Collapsed;
                    break;
            }

        }
        //Cerrrar Aplicacion
        private void Button_Click_Cerrar(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        //Buscar fotografia en la computadora local
        private void ExaminarFoto(object sender, RoutedEventArgs e)
        {
            try
            {

                openFileDialog1.Title = "Abrir imagen";
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog1.ShowDialog() == true)
                {
                    foreach (string filename in openFileDialog1.FileNames)
                        ListBoxDepa.Items.Add(filename);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error");
            }
        }
        //Eliminar Fotos de Edificio en su lista
        private void ListBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBoxDepa.SelectedItem != null)
            {
                try
                {
                    while (ListBoxDepa.SelectedItems.Count > 0)
                    {
                        ListBoxDepa.Items.Remove(ListBoxDepa.SelectedItems[0]);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("El archivo no pudo ser eliminado");
                }
              
            }
        }
        // Buscar Fotografias de edificio
        private void ExaminarFotoEdi(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                FotoEdi.Text = openFileDialog1.FileName;
            }
        }

        private void btn_buscarEdi(object sender, RoutedEventArgs e)
        {




        }
        // Crear edificio 
        private void CreateEdi(object sender, RoutedEventArgs e)
        {
            try
            {
                Edificio edi = new Edificio();

                edi.nombre = NombreEdi.Text;
                edi.direccion_edificio = DireccionEdi.Text;
                edi.telefono = int.Parse(TelefonoEdi.Text);
                edi.foto = FotoEdi.Text;
                edi.fk_id_comuna = 1;    //ComunaEdi.SelectedIndex;

                var tokenisado = login.token.token;

               MessageBox.Show(Conexion.CrearEdi(tokenisado, edi));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }
        //Actualizar atribustos del edificio
        private void btn_ActualizarEdi(object sender, RoutedEventArgs e)
        {
            try
            {
                Edificio ed = new Edificio();

                ed.nombre = NombreEdi.Text;
                ed.direccion_edificio = DireccionEdi.Text;
                ed.telefono = int.Parse(TelefonoEdi.Text);
                ed.foto = FotoEdi.Text;
                ed.fk_id_comuna = 1;

                var tokenisado = login.token.token;

                Console.WriteLine(Conexion.ActualizarEdi(tokenisado,ed, 1));
            }catch(Exception ex)
            {
                MessageBox.Show("Error : Verificar los datos");
            }
        }
        // Agregar un departamento al sistema 
        private void CrearDepa(object sender, RoutedEventArgs e)
        {
            try
            {
                Departamento depa = new Departamento();


                string fotosDepa = string.Join(" ", ListBoxDepa.Items.Cast<String>().ToList());


                depa.numero_habitacion = int.Parse(HabitacionDepa.Text);
                depa.numero_habitaciones = int.Parse(HabitacionesDepa.Text);
                depa.metros_cuadrados = int.Parse(MetrosDepa.Text);
                depa.banios = int.Parse(BaniosDepa.Text);
                depa.piso = int.Parse(PisoDepa.Text);
                depa.precio_noche = int.Parse(ValorDepa.Text);
                depa.foto = fotosDepa;
                depa.fk_id_edificio = 1; //EdificioDepa.SelectedIndex;
                depa.fk_id_estado = 1;    //EstadoDepa.SelectedIndex;

                var tokenisado = login.token.token;

                MessageBox.Show(Conexion.CrearDepa(tokenisado, depa));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : Departamento no creado , Verificar los datos");
            }
            
        }
        // Actualizar Departamento 
        private void btn_ActualizarDepa(object sender, RoutedEventArgs e)
        {
            try
            {
                Departamento dep = new Departamento();

                string fotosDepa = string.Join(" ", ListBoxDepa.Items.Cast<String>().ToList());


                dep.numero_habitacion = int.Parse(HabitacionDepa.Text);
                dep.numero_habitaciones = int.Parse(HabitacionesDepa.Text);
                dep.metros_cuadrados = int.Parse(MetrosDepa.Text);
                dep.banios = int.Parse(BaniosDepa.Text);
                dep.piso = int.Parse(PisoDepa.Text);
                dep.precio_noche = int.Parse(ValorDepa.Text);
                dep.foto = fotosDepa;
                dep.fk_id_edificio = 1; //EdificioDepa.SelectedIndex;
                dep.fk_id_estado = 1;    //EstadoDepa.SelectedIndex;
                
                var tokenisado = login.token.token;

                MessageBox.Show(Conexion.ActualizarDepa(tokenisado, dep,1));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : Verificar los datos");
            }
            

        }
        // Eliminar departamento 
        private void EliminarDep_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ide = int.Parse(buscarDepa.Text);

                var tokenisado = login.token.token;

                MessageBox.Show(Conexion.EliminarDepa(tokenisado, ide));
            }catch(Exception ex)
            {
                MessageBox.Show("Error : El departamento no se elimino "+ex);
            }


        }

        //Agregar un nuevo usuario administrador o funcionario al sistema
        private void btn_agregarUsuario(object sender, RoutedEventArgs e)
        {
            AgregaUsuario usu = new AgregaUsuario();
            try
            {
                usu.nombre = NombreUsu.Text;
                usu.contrasenia = ContraUsu.Text;
                usu.email = CorreoUsu.Text;
                usu.foto = "1";
                usu.rut = RutUsu.Text;
                usu.direccion = DirecUsu.Text;
                usu.telefono = TelefonoUsu.Text;
                usu.fk_id_tipo_usu = 2;

                MessageBox.Show(Conexion.AgregarUsu(usu));
            }catch(Exception ex)
            {
                MessageBox.Show("El usuario ya esta registrado o los datos estan mal ingresados");
            }

        }

 

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
           
        }


    }
}
