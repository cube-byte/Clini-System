using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Diagnostico
    {
        [Key]
        public int IdDiagnostico { get; set; }

        public string Descripcion { get; set; }

        public int IdAtencion { get; set; }

        [ForeignKey("IdAtencion")]
        public Atencion Atencion { get; set; }
    }
}
