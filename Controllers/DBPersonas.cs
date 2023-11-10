using SQLite;
using Tarea1._3_AndreaCastro.Models;

namespace Tarea1._3_AndreaCastro.Controllers
{
    public class DBPersonas
    {
        readonly SQLiteAsyncConnection dbPersona;
        public DBPersonas(string Path)
        {
            try
            {
                dbPersona = new SQLiteAsyncConnection(Path);
                //Creación de las tablas en la BD 
                dbPersona.CreateTableAsync<Personas>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        /* CRUD de la DB Sitios */
        public Task<int> GuardarPersona(Personas personas)
        {
            if (personas.id_persona != 0)
            {
                return dbPersona.UpdateAsync(personas); //Actualización
            }
            else
            {
                return dbPersona.InsertAsync(personas); //Inserción
            }
        }

        //Lectura
        public Task<List<Personas>> ObtenerlistaPersonas()
        {
            return dbPersona.Table<Personas>().ToListAsync();
        }

        //LecturaID
        public Task<Personas> ObtenerPersonaID(int id)
        {
            return dbPersona.Table<Personas>().Where(p => p.id_persona == id).FirstOrDefaultAsync();
        }

        //ActualizaciónID
        public Task<int> ActualizarPersona(Personas personas)
        {
            if (personas.id_persona != 0)
            {
                return dbPersona.UpdateAsync(personas);
            }
            else
            {
                throw new ArgumentException("¡Error! No se puede actualizar una persona que tenga ID: 0", nameof(personas));
            }
        }

        //Eliminación
        public Task<int> EliminarPersona(Personas personas)
        {
            return dbPersona.DeleteAsync(personas);
        }
    }
}
