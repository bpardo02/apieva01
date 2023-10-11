using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apitest.Model
{
    public class ContactosDTO
    {
        
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Rut { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string RutTrabajador { get; set; }
    }
}
