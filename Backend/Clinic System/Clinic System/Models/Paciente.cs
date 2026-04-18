namespace Clinic_System.Models
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string NombPaciente { get; set; }
        public string ApePaciente { get; set; }
        public string DniPaciente { get; set; }
        public DateTime FchNaci { get; set; }
        public string CorrPaciente { get; set; }
        public string TflPaciente { get; set; }

        // Relación
        public ICollection<Cita> Citas { get; set; }
    }
}
