using System.ComponentModel.DataAnnotations;

namespace Clinic_System.Models
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }

        public string NombreEspecialidad { get; set; }

        public ICollection<Medico>? Medicos { get; set; }
        public ICollection<TipoCita>? TipoCitas { get; set; }
    }
}
