using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public int IdEspecialidad { get; set; }

        [ForeignKey("IdEspecialidad")]
        public Especialidad? Especialidad { get; set; }

        public ICollection<Cita>? Citas { get; set; }
    }
}
