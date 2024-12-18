using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPaieApi.Models
{
    public class BulletinDeSalaire
    {
        // Composite primary key consisting of multiple columns
        [Key]
        public int BulletinDeSalaireID { get; set; }


        [Required]
        [ForeignKey("Id_FichAtachemnt")]
        public int Id_FichAtachemnt { get; set; }

        [Required]
        public FicheAttachemnt FicheAttachemnt { get; set; } 

        [Required]
        [ForeignKey("GrilleSalaireID")]
        public int GrilleSalaireID { get; set; } 

        public GrilleSalaire? GrilleSalaire { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18,2)")] 
        [Range(0, double.MaxValue, ErrorMessage = "Le salaire doit être un nombre positif.")]
        public decimal Salaire { get; set; } 
    }
}
