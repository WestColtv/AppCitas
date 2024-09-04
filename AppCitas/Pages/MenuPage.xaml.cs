using AppCitas.Modelos;

namespace AppCitas
{
    public partial class MenuPage : ContentPage
    {
        private Usuario _usuario;

        public MenuPage(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private async void OnReservarCitaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReservarCitaPage(_usuario));
        }

        private async void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}