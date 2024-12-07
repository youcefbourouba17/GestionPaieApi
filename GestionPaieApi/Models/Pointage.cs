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

        
        public double? HeuresTotales
        {
            get
            {
                if (DebutMatinee.HasValue && FinMatinee.HasValue && DebutApresMidi.HasValue && FinApresMidi.HasValue)
                {
                    TimeSpan matin = FinMatinee.Value - DebutMatinee.Value;
                    TimeSpan apresMidi = FinApresMidi.Value - DebutApresMidi.Value;

                    // Convert TimeSpan to total hours and add HeuresSupplementaires
                    double totalHours = (matin + apresMidi - DureeDePause.GetValueOrDefault()).TotalHours;
                    return totalHours + HeuresSupplementaires.GetValueOrDefault();
                }

                // Return null if any of the required times are missing
                return null;
            }
        }
    }
}
