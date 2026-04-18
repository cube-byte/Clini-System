using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }

        public DateTime FechaCita { get; set; }

        public string Descripcion { get; set; }

        public int IdPaciente { get; set; }

        public string Estado { get; set; }

        [ForeignKey("IdPaciente")]
        public Paciente Paciente { get; set; }

        public ICollection<Atencion> Atenciones { get; set; }
    }
}
