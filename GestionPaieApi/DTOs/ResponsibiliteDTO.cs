using System.ComponentModel.DataAnnotations;

namespace GestionPaieApi.DTOs
{
    public class ResponsibiliteDTO
    {
        [Required(ErrorMessage = "Le nom de la responsabilité est obligatoire.")]
        [MaxLength(100, ErrorMessage = "Le nom de la responsabilité ne peut pas dépasser 100 caractères.")]
        public string NomResp { get; set; }

        
        [Key]
        [Required(ErrorMessage = "Le nom de la responsabilité est obligatoire.")]
        public string ResponsabiliteID { get; set; }

        [MaxLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères.")]
        public string Description { get; set; }
    }
}
