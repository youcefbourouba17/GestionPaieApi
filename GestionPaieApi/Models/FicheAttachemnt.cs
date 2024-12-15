using GestionPaieApi.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPaieApi.Models
{
    public class FicheAttachemnt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FaID { get; set; }


        public string NomEtPrenom { get; set; }

        [ForeignKey("EmployeeID")]
        public string EmployeeID { get; set; }
        public Employe Employe { get; set; }
        [Required]
        public int JourTravaillee { get; set; }

        

        public int? AllocationFamiliale { get; set; }

        public double Remboursement { get; set; }

        public int Month {  get; set; }
        public int Year {  get; set; }
        public int PRI { get; set; }

        public int PRC { get; set; }
    }
}
