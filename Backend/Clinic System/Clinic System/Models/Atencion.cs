using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis;

namespace Clinic_System.Models
{
    public class Atencion
    {
        [Key]
        public int IdAtencion { get; set; }
        public DateTime FechaAtencion { get; set; }
        public string Observacion { get; set; }
        public int IdCita { get; set; }

        [ForeignKey("IdCita")]
        public Cita? Cita { get; set; }
        public ICollection<Diagnostico>? Diagnosticos { get; set; }
        public ICollection<Tratamiento>? Tratamientos { get; set; }
    }
}
