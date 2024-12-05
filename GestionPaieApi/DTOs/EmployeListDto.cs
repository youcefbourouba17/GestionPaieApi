namespace GestionPaieApi.DTOs
{
    public class EmployeDisplayDto
    {
        public string NSS { get; set; } 
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string FonctionPrincipale { get; set; }
        public string Grade { get; set; }
        public int? NombreEnfants { get; set; }
        public string Section { get; set; }
        public DateTime? DateRecrutement { get; set; }
    }
}
