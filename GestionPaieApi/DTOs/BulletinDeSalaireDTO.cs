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
        public Employe Employe { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Le mois ne peut pas dépasser 20 caractères.")]
        public string Mois { get; set; } 

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Le salaire doit être un nombre positif.")]
        public decimal Salaire { get; set; }
    }
}
