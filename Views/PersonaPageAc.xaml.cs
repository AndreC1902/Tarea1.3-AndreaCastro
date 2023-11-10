namespace Tarea1._3_AndreaCastro.Views;

public partial class PersonaPageAc : ContentPage
{
	public PersonaPageAc()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        txtNombres.Text = PersonasListPage.nombre;
        txtApellidos.Text = PersonasListPage.apellido;
        txtEdad.Text = PersonasListPage.edad.ToString();
        txtCorreo.Text = PersonasListPage.correo;
        txtDireccion.Text = PersonasListPage.direc;
    }

    private async void Salvar_ea(object sender, EventArgs e)
    {
        if (!(string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text) || 
            string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtEdad.Text) || 
            string.IsNullOrEmpty(txtDireccion.Text)))
        {
            var persona = new Models.Personas
            {
                id_persona = PersonasListPage.id,
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                Edad = Convert.ToInt32(txtEdad.Text),
                Correo = txtCorreo.Text,
                Direccion = txtDireccion.Text
            };

            await App.Instancia.ActualizarPersona(persona);
            await DisplayAlert("Aviso", "¡La persona ha sido editada/actualizada con éxito!", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Alerta", "Por favor complete todos los campos antes de guardar", "OK");
        }
    }
}