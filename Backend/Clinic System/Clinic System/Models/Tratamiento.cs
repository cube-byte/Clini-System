using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Tratamiento
    {
        [Key]
        public int IdTratamiento { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public string? Indicaciones { get; set; }

        public int IdAtencion { get; set; }

        [ForeignKey("IdAtencion")]
        public Atencion? Atencion { get; set; }

        public ICollection<DetalleTratamiento>? DetalleTratamientos { get; set; }
    }
}
