using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1._3_AndreaCastro.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int id_persona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
