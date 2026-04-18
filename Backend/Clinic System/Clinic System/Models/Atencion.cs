using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Atencion
    {
        [Key]
        public int idatencion { get; set; }
        public DateTime fchatencion { get; set; }
        public string observacion { get; set; }
        public int idcitas { get; set; }

        [ForeignKey("idcitas")]
        public Cita Cita { get; set; }
        public ICollection<Diagnostico> Diagnosticos { get; set; }
        public ICollection<Tratamiento> Tratamientos { get; set; }
    }
}
