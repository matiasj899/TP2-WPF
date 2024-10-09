using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TP2_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    int contador = 0;
    List<Alumnos> alumnos;
    public MainWindow()
    {
        InitializeComponent();
        alumnos = new List<Alumnos>();
    }

    private void GuardarAlumno(Alumnos alumno)
    {
        alumnos.Add(alumno);
    }

    private void AgregarAlumno(object sender, RoutedEventArgs e)
    {
        var window2 = new Window2();
        if (window2.ShowDialog() == true)
        {
            Alumnos nuevoAlumno = new Alumnos(
                window2.Nombre, window2.DNI, window2.Legajo, window2.Situacion,
                window2.Materia, window2.Asistencia, window2.TP1, window2.TP2,
                window2.TP3, window2.TP4, window2.Parcial1Min, window2.Parcial2Min, window2.NotaFinal);

            GuardarAlumno(nuevoAlumno);
            ActualizarLista();
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
                {
                    Children =
                    {
                        new TextBlock { Text = "TEST" },
                        new TextBlock { Text = "TEST" },
                        new TextBlock { Text = "TEST" },
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
                SegundoPanel.Children.Add(userBox);
                contador++;
            }
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
        SegundoPanel.Children.Clear();
        TercerPanel.Children.Clear();

        for (int i = 0; i < alumnos.Count; i++)
        {
            var userBox = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new System.Windows.Thickness(1),
                Margin = new System.Windows.Thickness(5),
                Padding = new System.Windows.Thickness(5),
                Child = new StackPanel
                {
                    Children =
                    {
                        new TextBlock { Text = $"Nombre: {alumnos[i].Nombre}" },
                        new TextBlock { Text = $"DNI: {alumnos[i].DNI}" },
                        new TextBlock { Text = $"Legajo: {alumnos[i].Legajo}" },
                        new TextBlock { Text = $"Situación: {alumnos[i].Situacion}" },
                        new TextBlock { Text = $"Materia: {alumnos[i].Materia}" },
                        new TextBlock { Text = $"Asistencia: {(alumnos[i].Asistencia ? "Presente" : "Ausente")}" },
                        new TextBlock { Text = $"TP1: {(alumnos[i].TP1 ? "Entregado" : "No entregado")}" },
                        new TextBlock { Text = $"TP2: {(alumnos[i].TP2 ? "Entregado" : "No entregado")}" },
                        new TextBlock { Text = $"TP3: {(alumnos[i].TP3 ? "Entregado" : "No entregado")}" },
                        new TextBlock { Text = $"TP4: {(alumnos[i].TP4 ? "Entregado" : "No entregado")}" },
                        new TextBlock { Text = $"Parcial 1 (Min): {alumnos[i].Parcial1Min}" },
                        new TextBlock { Text = $"Parcial 2 (Min): {alumnos[i].Parcial2Min}" },
                        new TextBlock { Text = $"Nota Final: {alumnos[i].NotaFinal}" }
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
                SegundoPanel.Children.Add(userBox);
                contador++;
            }
            else if (contador == 2)
            {
                TercerPanel.Children.Add(userBox);
                contador = 0;
            }
        }
    }

    public class Alumnos
    {
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public int Legajo { get; set; }
        public string Situacion { get; set; }
        public string Materia { get; set; }
        public bool Asistencia { get; set; }
        public bool TP1 { get; set; }
        public bool TP2 { get; set; }
        public bool TP3 { get; set; }
        public bool TP4 { get; set; }
        public int Parcial1Min { get; set; }
        public int Parcial2Min { get; set; }
        public float NotaFinal { get; set; }

        public Alumnos(string nombre, int dni, int legajo, string situacion, string materia, bool asistencia,
                       bool tp1, bool tp2, bool tp3, bool tp4, int parcial1Min, int parcial2Min, float notaFinal)
        {
            Nombre = nombre;
            DNI = dni;
            Legajo = legajo;
            Situacion = situacion;
            Materia = materia;
            Asistencia = asistencia;
            TP1 = tp1;
            TP2 = tp2;
            TP3 = tp3;
            TP4 = tp4;
            Parcial1Min = parcial1Min;
            Parcial2Min = parcial2Min;
            NotaFinal = notaFinal;
        }
    }
}
