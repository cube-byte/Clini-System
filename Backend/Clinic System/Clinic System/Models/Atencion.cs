namespace Clinic_System.Models
{
    public class Atencion
    {
        public int IdAtencion { get; set; }
        public DateTime FchAtencion { get; set; }
        public string Observacion { get; set; }
        public int IdCitas { get; set; }

        // Relación
        public Cita Cita { get; set; }
        public ICollection<Diagnostico> Diagnosticos { get; set; }
        public ICollection<Tratamiento> Tratamientos { get; set; }
    }
}
