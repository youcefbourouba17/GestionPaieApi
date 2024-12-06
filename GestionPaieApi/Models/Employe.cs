using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GestionPaieApi.Enum;

namespace GestionPaieApi.Models
{
    public class Employe
    {
        [Key]
        [MaxLength(20)]
        public string NSS { get; set; }

        [MaxLength(50)]
        public string Nom { get; set; }

        [MaxLength(50)]
        public string Prenom { get; set; }

        public DateTime? DateNaissance { get; set; }

        [MaxLength(100)]
        public string LieuNaissance { get; set; }


        public Sexe? Sexe { get; set; }

        [MaxLength(20)]
        public SituationFamiliale? SituationFamiliale { get; set; }

        [MaxLength(200)]
        public string? Adresse { get; set; }

        public DateTime? DateRecrutement { get; set; }

        [MaxLength(100)]
        public string FonctionPrincipale { get; set; }

        [MaxLength(50)]
        public string Grade { get; set; }

        public int? NombreEnfants { get; set; }

        [MaxLength(50)]
        public string Categorie { get; set; }

        [MaxLength(100)]
        public string Section { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TauxIndemniteNuisance { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PrimeVariable { get; set; }

        // Navigation property for responsibilities
        public ICollection<EmployeResponsabilites> EmployeResponsabilites { get; set; } = new List<EmployeResponsabilites>();

        public ICollection<LettreAccompagnee>? DemandesChangements { get; set; } = new List<LettreAccompagnee>();
    }
}
