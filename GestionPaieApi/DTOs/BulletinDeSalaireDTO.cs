using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GestionPaieApi.Models;

namespace GestionPaieApi.DTOs
{
    public class BulletinDeSalaireDTO
    {
        [Key]
        [Required]
        [ForeignKey("NSS_EMPLOYE")]
        public string NSS_EMPLOYE { get; set; }

        public FicheAttachemnt ficheAttachemnt { get; set; }
        public GrilleSalaire grilleSalaire { get; set; }

        [Required]
        public int Month
        {
            get => ficheAttachemnt?.Month ?? 0; // assuming Month comes from ficheAttachemnt
            set { /* Set logic here if needed */ }
        }

        [Required]
        public int Year
        {
            get => ficheAttachemnt?.Year ?? 0; // assuming Year comes from ficheAttachemnt
            set { /* Set logic here if needed */ }
        }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Le salaire doit être un nombre positif.")]
        public decimal Salaire { get; set; }
    }
}
