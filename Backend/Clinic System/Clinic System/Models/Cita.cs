using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Cita
    {
        [Key]
        public int idcitas { get; set; }
        public DateTime fchcitas { get; set; }
        public string descripcion { get; set; }
        public int idpaciente { get; set; }
        public string estado { get; set; }

        [ForeignKey("idpaciente")]
        public Paciente Paciente { get; set; }
        public ICollection<Atencion> Atenciones { get; set; }
    }
}
