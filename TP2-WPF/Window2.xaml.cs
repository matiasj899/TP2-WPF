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
        private const int MaxLegajo = 100000;

        // Nuevas propiedades para los datos de la materia
        public string Materia { get; private set; } = null!;
        public bool Asistencia { get; private set; }
        public bool TP1 { get; private set; }
        public bool TP2 { get; private set; }
        public bool TP3 { get; private set; }
        public bool TP4 { get; private set; }
        public int Parcial1Min { get; private set; }
        public int Parcial1Max { get; private set; }
        public int Parcial2Min { get; private set; }
        public int Parcial2Max { get; private set; }
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
            if (string.IsNullOrEmpty(NombreBox.Text)) // Revisa que no esté vacío
                MessageBox.Show("El nombre no puede quedar vacío.");
            else
                bul++;
            if ((NombreBox.Text).Length > LongitudMaximaNombre) // Revisa que tenga menos de 50 caracteres
                MessageBox.Show($"El nombre no puede tener más de {LongitudMaximaNombre} caracteres.");
            else
                bul++;
            if (!int.TryParse(DNITexto, out dni) || dni < 0 || dni > MaxDNI) // Revisa si el tipo de datos es correcto
                MessageBox.Show("DNI inválido, intente de nuevo.");
            else
                bul++;
            HashSet<int> legajosUsados = new HashSet<int>();


            Random random = new Random(); // genera números aleatorios

            if (!int.TryParse(LegajoTexto, out legajo) || legajo < 0 || legajo > MaxLegajo)
            {
                legajo = random.Next(0, MaxLegajo + 1);
                MessageBox.Show($"Nuevo usuario: se le ha asignado el número de legajo {legajo}.");
            }
            else
            {
                bul++;
            }

            // Validación del ComboBox de Situación
            if (SituacionComboBox.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar la situación del alumno (Promocionó o Rinde Final).");
            }
            else
            {
                // Almacena la situación seleccionada
                bul++;
            }

            // Validación de los datos de la materia
            if (string.IsNullOrEmpty(MateriaBox.Text))
            {
                MessageBox.Show("Debe ingresar una materia.");
                return;
            }

            // Validación de los parciales
            if (!int.TryParse(Parcial1MinBox.Text, out int parcial1Min) )
            {
                MessageBox.Show("Parcial 1: Debe ingresar valores numéricos.");
                return;
            }

            if (!int.TryParse(Parcial2MinBox.Text, out int parcial2Min) )
            {
                MessageBox.Show("Parcial 2: Debe ingresar valores numéricos.");
                return;
            }

            // Validación de la nota final
            if (!float.TryParse(NotaFinalBox.Text, out float notaFinal))
            {
                MessageBox.Show("La nota final debe ser un número válido.");
                return;
            }

            // Si todas las validaciones pasan
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

                Parcial1Min = parcial1Min;
               
                Parcial2Min = parcial2Min;
               
                NotaFinal = notaFinal;

                // Se cierra la ventana y se envían los datos
                DialogResult = true;
                Close();
            }
        }

        // Clase Estudiante extendida con más atributos
        class Estudiante
        {
            private string materia;
            private bool asistencia;
            private bool tp1;
            private bool tp2;
            private bool tp3;
            private bool tp4;
            private int parcial1Min;
            private int parcial1Max;
            private int parcial2Min;
            private int parcial2Max;
            private float notaFinal;

            public Estudiante(string materia, bool asistencia, bool tp1Entregado, bool tp2Entregado, bool tp3Entregado, bool tp4Entregado,
                              int parcial1Min, int parcial1Max, int parcial2Min, int parcial2Max, float notaFinal)
            {
                this.materia = materia;
                this.asistencia = asistencia;
                tp1 = tp1Entregado;
                tp2 = tp2Entregado;
                tp3 = tp3Entregado;
                tp4 = tp4Entregado;
                this.parcial1Min = parcial1Min;
                this.parcial1Max = parcial1Max;
                this.parcial2Min = parcial2Min;
                this.parcial2Max = parcial2Max;
                this.notaFinal = notaFinal;
            }

            // Métodos para obtener los valores
            public string GetMateria() { return materia; }
            public bool GetAsistencia() { return asistencia; }
            public bool GetTP1() { return tp1; }
            public bool GetTP2() { return tp2; }
            public bool GetTP3() { return tp3; }
            public bool GetTP4() { return tp4; }
            public int GetParcial1Min() { return parcial1Min; }
            public int GetParcial1Max() { return parcial1Max; }
            public int GetParcial2Min() { return parcial2Min; }
            public int GetParcial2Max() { return parcial2Max; }
            public float GetNotaFinal() { return notaFinal; }
        }

        private void MostrarEstadoTPs()
        {
            Estudiante estudiante = new Estudiante("Matemática", true, true, false, true, true, 5, 8, 4, 9, 7.5f);

            MessageBox.Show($"Materia: {estudiante.GetMateria()}\n" +
                            $"Asistencia: {(estudiante.GetAsistencia() ? "Presente" : "Ausente")}\n" +
                            $"TP1 entregado en fecha: {estudiante.GetTP1()}\n" +
                            $"TP2 entregado en fecha: {estudiante.GetTP2()}\n" +
                            $"TP3 entregado en fecha: {estudiante.GetTP3()}\n" +
                            $"TP4 entregado en fecha: {estudiante.GetTP4()}\n" +
                            $"Parcial 1 (Min): {estudiante.GetParcial1Min()}\n" +
                            $"Parcial 1 (Max): {estudiante.GetParcial1Max()}\n" +
                            $"Parcial 2 (Min): {estudiante.GetParcial2Min()}\n" +
                            $"Parcial 2 (Max): {estudiante.GetParcial2Max()}\n" +
                            $"Nota Final: {estudiante.GetNotaFinal()}");
        }

       
    }
}
