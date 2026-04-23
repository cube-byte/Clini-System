using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }
        public string? CodigoCita { get; set; }

        public DateTime FechaCita { get; set; }

        public string Descripcion { get; set; }

        public int IdPaciente { get; set; }

        public int IdMedico { get; set; }

        public int IdTipoCita { get; set; }


        public string Estado { get; set; } = "Pendiente";

        [ForeignKey("IdPaciente")]
        public Paciente? Paciente { get; set; }

        [ForeignKey("IdMedico")]
        public Medico? Medico { get; set; }

        [ForeignKey("IdTipoCita")]
        public TipoCita? TipoCita { get; set; }
        public Atencion? Atencion { get; set; }
    }
}
