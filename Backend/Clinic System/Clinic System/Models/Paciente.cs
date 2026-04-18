using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Clinic_System.Models
{
    public class Paciente
    {
        [Key]
        public int idpaciente { get; set; }
        public string nombpaciente { get; set; }
        public string apepaciente { get; set; }
        public string dnipaciente { get; set; }
        public DateTime fchnaci { get; set; }
        public string corrpaciente { get; set; }
        public string tflpaciente { get; set; }

        public ICollection<Cita> Citas { get; set; }

    }
}
