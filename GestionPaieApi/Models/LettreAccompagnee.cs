using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionPaieApi.Models
{
    public class LettreAccompagnee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DemandeId { get; set; }

        [Required] 
        public string EmployeId { get; set; }

        [ForeignKey("EmployeId")]
        public Employe Employe { get; set; }

        [Required]
        [MaxLength(100)] 
        public string TypeChangement { get; set; }

        [MaxLength(500)] 
        public string Raison { get; set; }

        [Required]
        public DateTime DateDemande { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(20)] 
        public string Statut { get; set; } = "En attente";

        [MaxLength(500)] 
        public string Commentaires { get; set; }
    }
}
