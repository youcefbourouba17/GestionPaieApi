using System.ComponentModel.DataAnnotations;

namespace GestionPaieApi.DTOs
{
    public class GrilleSalaireDTO
    {
        

        [Required]
        [MaxLength(15, ErrorMessage = "Le NSS de l'employé ne peut pas dépasser 15 caractères.")]
        public string NSS_EMPLOYE { get; set; } 

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Le salaire de base doit être un nombre positif.")]
        public decimal BaseSalary { get; set; } 

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Le salaire net doit être un nombre positif.")]
        public decimal SalaireNet { get; set; } 

        [Required]
        [MaxLength(10, ErrorMessage = "Le grade ne peut pas dépasser 10 caractères.")]
        public string Grd { get; set; } 
    }
}
