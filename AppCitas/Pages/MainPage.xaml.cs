using AppCitas.Modelos;

namespace AppCitas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Agregar opciones al Picker de tipo de documento
            TipoDocumentoPicker.ItemsSource = new List<string>
            {
                "DNI",
                "Pasaporte",
                "Carnet de Extranjería",
                "Otro"
            };
        }

        private async void OnIniciarSesionClicked(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {
                TipoDocumento = TipoDocumentoPicker.SelectedItem?.ToString(),
                Usuarios = Usuarios.Text,
                Contraseña = Contraseña.Text
            };

            // Aquí deberías validar las credenciales del usuario
            // Por ahora, simplemente navegaremos a la página de menú

            if (!string.IsNullOrWhiteSpace(usuario.TipoDocumento) &&
                !string.IsNullOrWhiteSpace(usuario.Usuarios) &&
                !string.IsNullOrWhiteSpace(usuario.Contraseña))
            {
                await Navigation.PushAsync(new MenuPage(usuario));
            }
            else
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
            }
        }
    }
}