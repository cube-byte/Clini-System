using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Seguimiento
    {
        [Key]
        public int IdSeguimiento { get; set; }

        public int IdTratamiento { get; set; }

        public DateTime FechaSeguimiento { get; set; }

        public string Estado { get; set; }

        public string Descripcion { get; set; }

        [ForeignKey("IdTratamiento")]
        public Tratamiento Tratamiento { get; set; }
    }
}
