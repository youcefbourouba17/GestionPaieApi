using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPaieApi.Models
{
    public class GrilleSalaire
    {
        [Required]
        [Key, ForeignKey("NSS_EMPLOYE")]
        public string NSS_EMPLOYE { get; set; }

        public Employe Employe { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BaseSalary { get; set; } // Explicit precision

        

        [Required]
        [MaxLength(10, ErrorMessage = "Le grade ne peut pas dépasser 10 caractères.")]
        public string Grd { get; set; }
    }
}
