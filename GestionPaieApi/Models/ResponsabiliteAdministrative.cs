using System.ComponentModel.DataAnnotations;

namespace GestionPaieApi.Models
{
    public class ResponsabiliteAdministrative
    {
        [Key]
        [Required]
        [MaxLength(100)] 
        public string NomResp { get; set; }

        [MaxLength(500)] 
        public string Description { get; set; }
    }
}
