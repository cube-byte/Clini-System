using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Seguimiento
    {
        [Key]
        public int idseguimiento { get; set; }
        public int idtatratamiento { get; set; }
        public DateTime fechasegui { get; set; }
        public string estado { get; set; }
        public string descipcion { get; set; }

        [ForeignKey("idtatratamiento")]
        public Tratamiento Tratamiento { get; set; }
    }
}
