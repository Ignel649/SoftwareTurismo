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
using Microsoft.Win32;

namespace WpfTurismo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
                    break;
                case 1:
                    GridCursor.Background = Brushes.YellowGreen;
                    GridMain.Visibility = Visibility.Collapsed;
                    GridDepa.Visibility = Visibility.Visible;
                    GridArri.Visibility = Visibility.Collapsed;
                    GridAdmin.Visibility = Visibility.Collapsed;
                    GridFina.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    GridCursor.Background = Brushes.MistyRose;
                    GridMain.Visibility = Visibility.Collapsed;
                    GridDepa.Visibility = Visibility.Collapsed;
                    GridArri.Visibility = Visibility.Visible;
                    GridAdmin.Visibility = Visibility.Collapsed;
                    GridFina.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    GridCursor.Background = Brushes.Orange;
                    GridMain.Visibility = Visibility.Collapsed;
                    GridDepa.Visibility = Visibility.Collapsed;
                    GridArri.Visibility = Visibility.Collapsed;
                    GridAdmin.Visibility = Visibility.Visible;
                    GridFina.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    GridCursor.Background = Brushes.DodgerBlue;
                    GridMain.Visibility = Visibility.Collapsed;
                    GridDepa.Visibility = Visibility.Collapsed;
                    GridArri.Visibility = Visibility.Collapsed;
                    GridAdmin.Visibility = Visibility.Collapsed;
                    GridFina.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void Button_Click_Cerrar(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
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
                        ListBox1.Items.Add(filename);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error");
            }
        }
        private void ListBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                try
                {
                    while (ListBox1.SelectedItems.Count > 0)
                    {
                        ListBox1.Items.Remove(ListBox1.SelectedItems[0]);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("El archivo no pudo ser eliminado");
                }
              
            }
        }

        private void ExaminarFotoEdi(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                LabelBox1.Text = openFileDialog1.FileName;
            }
        }

        private void EliminarDep_Click(object sender, RoutedEventArgs e)
        {

            
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
