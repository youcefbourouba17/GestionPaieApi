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

        [Required]
        public int Month { get; set; }
        [Required]
        public int Year { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Le salaire doit être un nombre positif.")]
        public decimal Salaire { get; set; }
    }
}
