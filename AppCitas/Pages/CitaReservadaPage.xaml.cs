using AppCitas.Modelos;

namespace AppCitas
{
    public partial class CitaReservadaPage : ContentPage
    {
        private Usuario _usuario;
        private Cita _cita;

        public CitaReservadaPage(Usuario usuario, Cita cita)
        {
            InitializeComponent();
            _usuario = usuario;
            _cita = cita;

            FechaLabel.Text = $"Día: {_cita.Fecha:dd/MM/yyyy}";
            EspecialidadLabel.Text = $"Especialidad: {_cita.Especialidad}";
            MedicoLabel.Text = $"Médico: {_cita.Medico}";
        }

        private async void OnCancelarCitaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CitaCanceladaPage(_usuario));
        }

        private async void OnAceptarClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}