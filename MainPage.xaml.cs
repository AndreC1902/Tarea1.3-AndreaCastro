using Tarea1._3_AndreaCastro.Views;

namespace Tarea1._3_AndreaCastro
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Salvar(object sender, System.EventArgs e)
        {
            if(!(string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text) || 
                string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtEdad.Text) || 
                    string.IsNullOrEmpty(txtDireccion.Text)))
            {
                var persona = new Models.Personas
                {
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Edad = Convert.ToInt32(txtEdad.Text),
                    Correo = txtCorreo.Text,
                    Direccion = txtDireccion.Text
                };

                if (await App.Instancia.GuardarPersona(persona) > 0)
                {
                    await DisplayAlert("Aviso", "¡La persona ha sido agregada con éxito!", "OK");
                    // Restablecer los campos después de guardar.
                    txtNombres.Text = "";
                    txtApellidos.Text = "";
                    txtEdad.Text = "";
                    txtCorreo.Text = "";
                    txtDireccion.Text = "";
                    txtNombres.Focus();
                }
                else
                {
                    await DisplayAlert("Alerta", "¡Ha ocurrido un error!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Por favor complete todos los campos antes de guardar", "OK");
            }
        }

        private async void Listado(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PersonasListPage());
        }
    }
}