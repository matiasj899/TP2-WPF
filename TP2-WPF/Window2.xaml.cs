using Microsoft.Windows.Themes;
using System;
using System.Windows;
using System.Windows.Controls;

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
        public string Situacion { get; private set; } = null!;
        private const int LongitudMaximaNombre = 50;
        private const int MaxDNI = 100000000;
        private const int MaxLegajo = 100000000;

        // Nuevas propiedades para los datos de la materia
        public string Materia { get; private set; } = null!;
        public bool Asistencia { get; private set; }
        public bool TP1 { get; private set; }
        public bool TP2 { get; private set; }
        public bool TP3 { get; private set; }
        public bool TP4 { get; private set; }
        public int Parcial1Min { get; private set; }
        public int Parcial2Min { get; private set; }
        public float NotaFinal { get; private set; }

        public Window2()
        {
            InitializeComponent();
        }

        private void AgregarAlumno2(object sender, RoutedEventArgs e)
        {
            string DNITexto = DNIBox.Text, LegajoTexto = LegajoBox.Text;
            int dni, legajo, bul = 0;

            // Validación de los datos del alumno
            if (string.IsNullOrEmpty(NombreBox.Text))
                MessageBox.Show("El nombre no puede quedar vacío.");
            else
                bul++;
            if ((NombreBox.Text).Length > LongitudMaximaNombre)
                MessageBox.Show($"El nombre no puede tener más de {LongitudMaximaNombre} caracteres.");
            else
                bul++;
            if (!int.TryParse(DNITexto, out dni) || dni < 0 || dni > MaxDNI)
                MessageBox.Show("DNI inválido, intente de nuevo.");
            else
                bul++;
            if (!int.TryParse(LegajoTexto, out legajo) || legajo < 0 || legajo > MaxLegajo)
                MessageBox.Show("Legajo inválido, intente de nuevo.");
            else
                bul++;

            if (SituacionComboBox.SelectedItem == null)
                MessageBox.Show("Debe seleccionar la situación del alumno (Promocionó o Rinde Final).");
            else
                bul++;

            if (bul == 5)
            {
                Nombre = NombreBox.Text;
                DNI = dni;
                Legajo = legajo;
                ComboBoxItem selectedSituacion = (ComboBoxItem)SituacionComboBox.SelectedItem;
                Situacion = selectedSituacion.Content.ToString();

                // Captura de los datos de la materia
                Materia = MateriaBox.Text;
                Asistencia = AsistenciaBox.IsChecked == true;
                TP1 = TP1Box.IsChecked == true;
                TP2 = TP2Box.IsChecked == true;
                TP3 = TP3Box.IsChecked == true;
                TP4 = TP4Box.IsChecked == true;
                Parcial1Min = int.Parse(Parcial1MinBox.Text);
                Parcial2Min = int.Parse(Parcial2MinBox.Text);
                NotaFinal = float.Parse(NotaFinalBox.Text);

                DialogResult = true;
            }
        }
    }
}
