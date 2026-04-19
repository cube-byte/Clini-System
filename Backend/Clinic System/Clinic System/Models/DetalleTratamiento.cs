using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class DetalleTratamiento
    {
        [Key]
        public int IdDetalle { get; set; }

        public int IdTratamiento { get; set; }

        public int IdMedicamento { get; set; }

        public string Dosis { get; set; }

        public int DuracionDias { get; set; }

        [ForeignKey("IdTratamiento")]
        public Tratamiento? Tratamiento { get; set; }

        [ForeignKey("IdMedicamento")]
        public Medicamento? Medicamento { get; set; }
    }
}
