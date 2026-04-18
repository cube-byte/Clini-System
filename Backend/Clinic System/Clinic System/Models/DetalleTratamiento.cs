using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class DetalleTratamiento
    {
        [Key]
        public int iddatalle { get; set; }

        public int idtatratamiento { get; set; }
        public int idmedicamento { get; set; }
        public string dosis { get; set; }
        public int duraciondias { get; set; }

        [ForeignKey("idtatratamiento")]
        public Tratamiento Tratamiento { get; set; }
        [ForeignKey("idmedicamento")]
        public Medicamento Medicamento { get; set; }
    }
}
