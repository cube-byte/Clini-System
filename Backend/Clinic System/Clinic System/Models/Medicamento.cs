using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_System.Models
{
    public class Medicamento
    {
        [Key]
        public int idmedicamento { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }

        public int idcategoria { get; set; }

        [ForeignKey("idcategoria")]
        public Categoria Categoria { get; set; }
    }
}
