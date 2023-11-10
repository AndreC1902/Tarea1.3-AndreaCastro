using Tarea1._3_AndreaCastro.Models;

namespace Tarea1._3_AndreaCastro.Views;

public partial class PersonasListPage : ContentPage
{
    private Personas persona;
    public static string nombre, apellido, correo, direc;
    public static int id, edad;
    public PersonasListPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        ListaPersona.ItemsSource = await App.Instancia.ObtenerlistaPersonas();
    }

    private void Persona_OnItemTapped(Object sender, SelectionChangedEventArgs e)
    {
        persona = e.CurrentSelection.FirstOrDefault() as Personas;

        nombre = persona.Nombres;
        apellido = persona.Apellidos;
        edad = persona.Edad;
        correo = persona.Correo;
        direc = persona.Direccion;
        id = persona.id_persona;
    }

    private async void btnactualizar(object sender, EventArgs e)
    {
        if (persona != null)
        {
            var response = await DisplayAlert("Aviso", "¿Desea editar/actualizar los datos de la persona seleccionada?", "NO", "SI");

            if (!response)
            {
                await Navigation.PushAsync(new PersonaPageAc());
                persona = null;
            }
        }
        else
        {
            await DisplayAlert("Aviso", "Por favor, Seleccione a una persona", "Ok");
        }
    }

    private async void btneliminar(object sender, EventArgs e)
    {
        if (persona != null)
        {
            var response = await DisplayAlert("Confirmación", "¿Desea eliminar a la persona seleccionada?", "NO", "SI");

            if (!response)
            {
                await App.Instancia.EliminarPersona(persona);
                ListaPersona.ItemsSource = await App.Instancia.ObtenerlistaPersonas();
                persona = null;
            }
        }
        else
        {
            await DisplayAlert("Aviso", "Por favor, Seleccione a una persona", "Ok");
        }
    }
}