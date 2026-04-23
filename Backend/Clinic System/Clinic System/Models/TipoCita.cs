using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Clinic_System.Models
{
    public class TipoCita
    {
        [Key]
        public int IdTipoCita { get; set; }

        public string NombreTipoCita { get; set; }

        public decimal Precio { get; set; }

        public int IdEspecialidad { get; set; }

        [ForeignKey("IdEspecialidad")]
        public Especialidad? Especialidad { get; set; }

        public ICollection<Cita>? Citas { get; set; }
    }
}
