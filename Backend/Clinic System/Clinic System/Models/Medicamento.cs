using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Clinic_System.Models
{
    public class Medicamento
    {
        [Key]
        public int IdMedicamento { get; set; }

        public string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int IdCategoria { get; set; }

        [ValidateNever]
        [ForeignKey("IdCategoria")]
        public Categoria? Categoria { get; set; }

        public ICollection<DetalleTratamiento>? DetalleTratamientos { get; set; }
    }
}
