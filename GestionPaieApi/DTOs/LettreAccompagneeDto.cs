namespace GestionPaieApi.DTOs
{
    public class LettreAccompagneeDto
    {
        
        public int? DemandId { get; set; } =null;
        public string EmployeId { get; set; }

        public string TypeChangement { get; set; }

        public string Raison { get; set; }

        public DateTime DateDemande { get; set; }

        public string Statut { get; set; }

        public string Commentaires { get; set; }
    }
}
