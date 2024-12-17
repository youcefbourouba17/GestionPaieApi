using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPaieApi.Models
{
    public class BulletinDeSalaire
    {
        [Key]
        [Required]
        [ForeignKey("Id_FichAtachemnt")]
        public string Id_FichAtachemnt { get; set; } // Primary Key

        [Required]
        public FicheAttachemnt FicheAttachemnt { get; set; } // Navigation property for attachment
        

        [Required]
        [ForeignKey("GrilleSalaireID")]
        public string GrilleSalaireID { get; set; } // Foreign key to Employe

        public GrilleSalaire GrilleSalaire { get; set; } // Navigation property for Employe

        [Required]
        [StringLength(20, ErrorMessage = "Le mois ne peut pas dépasser 20 caractères.")]
        public string Mois { get; set; } // Month

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Explicit precision for SQL Server
        [Range(0, double.MaxValue, ErrorMessage = "Le salaire doit être un nombre positif.")]
        public decimal Salaire { get; set; } // Salary
    }
}
