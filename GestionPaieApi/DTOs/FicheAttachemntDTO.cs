using GestionPaieApi.Enum;
using System.ComponentModel.DataAnnotations;

namespace GestionPaieApi.DTOs
{
    public class FicheAttachemntDTO
    {
        public int? FaID { get; set; } = null;

        public string EmployeeID { get; set; }
        public double Remboursement { get; set; }
        [Range(1, 12, ErrorMessage = "Month must be between 1 and 12.")]
        public int Month { get; set; }
        [Range(1900, 2100, ErrorMessage = "Year must be a valid year.")]
        public int Year { get; set; }

        [Range(0, 10, ErrorMessage = "PRI must be between 0 and 10.")]
        public int PRI { get; set; }


        [Range(0, 30, ErrorMessage = "PRC must be between 0 and 30.")]
        public int PRC { get; set; }
    }
}
