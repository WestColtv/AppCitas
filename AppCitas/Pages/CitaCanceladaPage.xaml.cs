using AppCitas.Modelos;

namespace AppCitas
{
    public partial class CitaCanceladaPage : ContentPage
    {
        private Usuario _usuario;

        public CitaCanceladaPage(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private async void OnAceptarClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}