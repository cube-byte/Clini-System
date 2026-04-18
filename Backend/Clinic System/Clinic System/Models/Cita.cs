namespace Clinic_System.Models
{
    public class Cita
    {
        public int IdCitas { get; set; }
        public DateTime FchCitas { get; set; }
        public string Descripcion { get; set; }
        public int IdPaciente { get; set; }
        public string Estado { get; set; }

        // Relación
        public Paciente Paciente { get; set; }
        public ICollection<Atencion> Atenciones { get; set; }
    }
}
