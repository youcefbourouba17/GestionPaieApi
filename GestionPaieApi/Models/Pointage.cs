using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionPaieApi.Models
{
    public class Pointage
    {
        /// <summary>
        /// Id is composed with 2 attributes (Date, EmployeId)
        /// </summary>

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string EmployeId { get; set; }

        [ForeignKey("EmployeId")]
        public Employe? Employe { get; set; }

        
        public TimeSpan? DebutMatinee { get; set; }

        
        public TimeSpan? FinMatinee { get; set; }

        
        public TimeSpan? DebutApresMidi { get; set; }

        
        public TimeSpan? FinApresMidi { get; set; }

        
        public TimeSpan? DureeDePause { get; set; }

        
        public double? HeuresSupplementaires { get; set; }

        
        public double? HeuresTotales { get; set; }
    }
}
