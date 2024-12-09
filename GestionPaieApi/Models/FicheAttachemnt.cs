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

        [Required]
        public int JourTravaillee { get; set; }
        public int PrimePers { get; set; }
        public PrecariteType Precarite { get; set; }

        public int AllocationFamiliale { get; set; }

        public double Remboursement { get; set; }

        public int Month {  get; set; }
        public int Year {  get; set; }
    }
}
