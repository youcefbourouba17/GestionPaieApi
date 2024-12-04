using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GestionPaieApi.Models
{
    public class ResponsabiliteAdministrative
    {
        [Key]
        public string ResponsabiliteID { get; set; }

        
        [MaxLength(100)]
        public string NomResp { get; set; }

        [MaxLength(500)] 
        public string Description { get; set; }

        public ICollection<EmployeResponsabilites> EmployeResponsabilites { get; set; } = new List<EmployeResponsabilites>();
    }
}
