using AppCitas.Modelos;

namespace AppCitas
{
    public partial class ReservarCitaPage : ContentPage
    {
        private Usuario _usuario;
        private Dictionary<string, List<string>> _medicosPorEspecialidad;

        public ReservarCitaPage(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            // Inicializar el diccionario de médicos por especialidad
            _medicosPorEspecialidad = new Dictionary<string, List<string>>
            {
                {"Medicina General", new List<string> {"Dra. Ana López", "Dr. Carlos Rodríguez"}},
                {"Pediatría", new List<string> {"Dra. María González", "Dr. Juan Pérez"}},
                {"Cardiología", new List<string> {"Dr. Roberto Sánchez", "Dra. Laura Martínez"}},
                {"Dermatología", new List<string> {"Dra. Sofía Vargas", "Dr. Andrés Mora"}},
                {"Oftalmología", new List<string> {"Dr. Javier Ruiz", "Dra. Carmen Jiménez"}}
            };

            // Agregar opciones al Picker de especialidades
            EspecialidadPicker.ItemsSource = _medicosPorEspecialidad.Keys.ToList();

            // Configurar el evento de selección de especialidad
            EspecialidadPicker.SelectedIndexChanged += OnEspecialidadSelected;

            // Configurar el DatePicker
            FechaPicker.MinimumDate = DateTime.Today;
            FechaPicker.MaximumDate = DateTime.Today.AddMonths(3);
        }

        private void OnEspecialidadSelected(object sender, EventArgs e)
        {
            var especialidadSeleccionada = EspecialidadPicker.SelectedItem as string;
            if (especialidadSeleccionada != null && _medicosPorEspecialidad.ContainsKey(especialidadSeleccionada))
            {
                MedicoPicker.ItemsSource = _medicosPorEspecialidad[especialidadSeleccionada];
                MedicoPicker.IsEnabled = true;
            }
            else
            {
                MedicoPicker.ItemsSource = null;
                MedicoPicker.IsEnabled = false;
            }
        }

        private async void OnReservarClicked(object sender, EventArgs e)
        {
            var cita = new Cita
            {
                Fecha = FechaPicker.Date,
                Especialidad = EspecialidadPicker.SelectedItem?.ToString(),
                Medico = MedicoPicker.SelectedItem?.ToString()
            };

            await Navigation.PushAsync(new CitaReservadaPage(_usuario, cita));
        }
    }
}