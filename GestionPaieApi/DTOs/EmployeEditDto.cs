using System;
using System.ComponentModel.DataAnnotations;
using GestionPaieApi.Enum;

namespace GestionPaieApi.Models
{
    public class EmployeEditDto
    {
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
        public int? SituationFamiliale { get; set; }

        [MaxLength(200)]
        public string? Adresse { get; set; }

        public DateTime? DateRecrutement { get; set; }

        [MaxLength(100)]
        public string FonctionPrincipale { get; set; }

        [MaxLength(50)]
        public string Grade { get; set; }

        [Range(0,15, ErrorMessage = "wch equipe ta3 foot ?.")]
        public int? NombreEnfants { get; set; }

        [MaxLength(50)]
        public string Categorie { get; set; }

        [MaxLength(100)]
        public string Section { get; set; }

        public decimal? TauxIndemniteNuisance { get; set; }

        public decimal? PrimeVariable { get; set; }

        public ICollection<string> EmployeResponsabilites { get; set; } = new List<string>();
    }
}
