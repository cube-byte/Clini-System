using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Tratamiento
    {
        [Key]
        public int idtatratamiento { get; set; }
        public DateTime fchinicio { get; set; }
        public DateTime fchfin { get; set; }
        public string indicaciones { get; set; }
        public int idatencion { get; set; }

        [ForeignKey("idatencion")]
        public Atencion Atencion { get; set; }
        public ICollection<DetalleTratamiento> DetalleTratamientos { get; set; }
        public ICollection<Seguimiento> Seguimientos { get; set; }
    }
}
