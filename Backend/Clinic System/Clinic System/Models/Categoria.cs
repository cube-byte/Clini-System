using System.ComponentModel.DataAnnotations;

namespace Clinic_System.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; }

        public ICollection<Medicamento> Medicamentos { get; set; }
    }
}
