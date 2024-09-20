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
    int contador = 0 ;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void AgregarUsuario(object sender, RoutedEventArgs e)
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
                    new TextBlock { Text = "BUENAS"},
                    new TextBlock { Text = "BUENAS"},
                    new TextBlock { Text = "BUENAS"},

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
        else if(contador == 2)
        {
            TercerPanel.Children.Add(userBox);
            contador = 0 ;
        }

    }
}