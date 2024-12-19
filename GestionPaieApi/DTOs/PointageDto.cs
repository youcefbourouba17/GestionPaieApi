namespace GestionPaieApi.DTOs
{
    public class PointageDto
    {
        public DateTime Date { get; set; }
        public string EmployeId { get; set; }
        public TimeSpan? DebutMatinee { get; set; }
        public TimeSpan? FinMatinee { get; set; }
        public TimeSpan? DebutApresMidi { get; set; }
        public TimeSpan? FinApresMidi { get; set; }
        public double? HeuresTotales { get; set; }
    }
}
