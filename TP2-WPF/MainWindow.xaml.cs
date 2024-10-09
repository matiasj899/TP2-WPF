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

namespace TP2_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    int contador = 0;
    List<Alumnos> alumnos ;
    public MainWindow()
    {
        InitializeComponent();
        alumnos = new List<Alumnos>();


    }
    private void GuardarAlumno(Alumnos alumno)
    {

        alumnos.Add(alumno) ;
    }

    private void AgregarAlumno(object sender, RoutedEventArgs e)
    {
        var Window2= new Window2() ;
        if(Window2.ShowDialog() == true)
        {
            Alumnos nuevoAlumno = new Alumnos(Window2.Nombre, Window2.DNI, Window2.Legajo) ; 
            GuardarAlumno(nuevoAlumno) ; //Recibe los datos de la segunda ventana y los guarda.
            ActualizarLista() ; 
        }

    }
    private void AgregarAlumnos(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 50; i++)
        {
            var userBox = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new System.Windows.Thickness(1),
                Margin = new System.Windows.Thickness(5),
                Padding = new System.Windows.Thickness(5),
                Child = new StackPanel
                {                                                                   //Crea los paneles en un bucle.
                    Children =
                    {
                        new TextBlock { Text = "TEST"},
                        new TextBlock { Text = "TEST"},
                        new TextBlock { Text = "TEST"},
                    }
                }
            };
            if (contador == 0)
            {
                PrimerPanel.Children.Add(userBox);
                contador++;
            }
            else if (contador == 1)
            {
                SegundoPanel.Children.Add(userBox);      //Decide en qué panel se va a añadir el alumno dependiendo
                contador++;                              // de la variable contador que se reinicia cada que llega
            }                                            // al tercer panel.
            else if (contador == 2)
            {
                TercerPanel.Children.Add(userBox);
                contador = 0;
            }
        }

    }

    private void ActualizarLista()
    {
        contador = 0;
        PrimerPanel.Children.Clear();
        SegundoPanel.Children.Clear(); //Mata a todos los niños de los paneles. (Los borra.)
        TercerPanel.Children.Clear();

        for (int i = 0;  i < alumnos.Count; i++)
        {
            var userBox = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new System.Windows.Thickness(1),
                Margin = new System.Windows.Thickness(5),
                Padding = new System.Windows.Thickness(5),
                Child = new StackPanel
                {                                                                   //Crea los paneles en un bucle.
                    Children =
                    {
                        new TextBlock { Text = alumnos[i].Nombre},
                        new TextBlock { Text = Convert.ToString(alumnos[i].DNI)},
                        new TextBlock { Text = Convert.ToString(alumnos[i].Legajo)},
                    }
                }
            };
            if (contador == 0)
            {
                PrimerPanel.Children.Add(userBox);
                contador++;
            }
            else if (contador == 1)
            {
                SegundoPanel.Children.Add(userBox);      //Decide en qué panel se va a añadir el alumno dependiendo
                contador++;                              // de la variable contador que se reinicia cada que llega
            }                                            // al tercer panel.
            else if (contador == 2)
            {
                TercerPanel.Children.Add(userBox);
                contador = 0;
            }
        }
    }

    public class Alumnos
    {
        public string Nombre ;
        public int DNI ;
        public int Legajo ;
        public Alumnos(string nombre, int dni, int legajo)
        {
            Nombre = nombre ;
            DNI = dni ;
            Legajo = legajo ;
        }
    }
}

float NotaFinal(float parcial1, float parcial2)
{
    float notaFinal = (parcial1 + parcial2) / 2;
    return notaFinal;
}
