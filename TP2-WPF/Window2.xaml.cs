using Microsoft.Windows.Themes;
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
using System.Windows.Shapes;

namespace TP2_WPF
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string Nombre { get; private set; } = null!;
        public int DNI { get; private set; } 
        public int Legajo { get; private set; }
        private const int LongitudMaximaNombre = 50 ;
        private const int MaxDNI = 100000000;
        private const int MaxLegajo = 100000000;


        public Window2()
        { 
            InitializeComponent() ;
        }

        

        private void AgregarAlumno2(object sender, RoutedEventArgs e)
        {
            string DNITexto = DNIBox.Text, LegajoTexto = LegajoBox.Text ;
            int dni, legajo, bul = 0;
            //Se necesitan estas variables de DNITexto y dni porque sino el out en el if no funciona.
            //bul es de booleano porque fue el único nombre que se me ocurrió, es para que se vayan dando "ticks"
            //cuando los datos se van validando.


            if (string.IsNullOrEmpty(NombreBox.Text)) //Revisa que no esté vacio
                MessageBox.Show("El nombre no puede quedar vacio.");
            else
                bul++ ;
            if ((NombreBox.Text).Length > LongitudMaximaNombre) //Revisa que tenga menos de 50 caracteres
                MessageBox.Show($"El nombre no puede tener más de {LongitudMaximaNombre}");
            else
                bul++;
            if (!int.TryParse(DNITexto, out dni) || dni < 0 || dni > MaxDNI) //Revisa si el tipo de datos es correcto
                MessageBox.Show("DNI inválido, intente de nuevo.");
            else
                bul++;
            if (!int.TryParse(LegajoTexto, out legajo) || legajo < 0 || legajo > MaxLegajo) //Revisa si el tipo de datos es correcto
                MessageBox.Show("Legajo inválido, intente de nuevo.");
            else
                bul++;
            if(bul == 4) //Si todos los ticks pasan, se le da los valores de los TextBox a las variables 
            {            // para ser enviadas a la lista del main
                Nombre = NombreBox.Text ;
                DNI = int.Parse(DNIBox.Text);
                Legajo = int.Parse(LegajoBox.Text);
                DialogResult = true;
                Close() ;
            }


        }
    }
}
