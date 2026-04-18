using System.ComponentModel.DataAnnotations;

namespace Clinic_System.Models
{
    public class Categoria
    {
        [Key]
        public int idcategoria { get; set; }
        public string nombcategoria { get; set; }


        public ICollection<Medicamento> Medicamentos { get; set; }
    }
}
