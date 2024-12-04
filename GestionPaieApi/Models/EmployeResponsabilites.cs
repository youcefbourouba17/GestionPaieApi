using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPaieApi.Models
{
    public class EmployeResponsabilites
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("EmployeID")]
        [Required]
        public string EmployeID { get; set; }

        public Employe? Employe { get; set; }

        [ForeignKey("ResponsabiliteID")]
        [Required]
        public string ResponsabiliteID { get; set; }

        public ResponsabiliteAdministrative Responsabilite { get; set; }
    }
}
