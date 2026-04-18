using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Diagnostico
    {
        [Key]
        public int iddiagnostico { get; set; }
        public string descripcion { get; set; }
        public int idatencion { get; set; }

        [ForeignKey("idatencion")]
        public Atencion Atencion { get; set; }
    }
}
