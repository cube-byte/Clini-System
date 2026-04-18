using System.ComponentModel.DataAnnotations;

namespace Clinic_System.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public ICollection<Cita>? Citas { get; set; }
    }
}
