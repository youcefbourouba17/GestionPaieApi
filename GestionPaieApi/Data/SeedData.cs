using GestionPaieApi.Enum;
using GestionPaieApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionPaieApi.Data
{
    public class SeedData
    {
        public static void Initialize(Dbcontext context)
        {
            // Seed ResponsabilitesAdministratives
            if (!context.ResponsabilitesAdministratives.Any())
            {
                context.ResponsabilitesAdministratives.AddRange(
                    new ResponsabiliteAdministrative
                    {

                        NomResp = "Responsable de Post",
                        Description = "Responsable du bon fonctionnement du bureau ou du poste."
                    },
                    new ResponsabiliteAdministrative
                    {

                        NomResp = "Chef Département",
                        Description = "Chef d'un département, gère les activités et ressources du département."
                    },
                    new ResponsabiliteAdministrative
                    {

                        NomResp = "Chef Service",
                        Description = "Responsable d'un service spécifique dans une organisation."
                    },
                    new ResponsabiliteAdministrative
                    {

                        NomResp = "Chef Projet",
                        Description = "Responsable de la gestion et coordination d'un projet."
                    },
                    new ResponsabiliteAdministrative
                    {

                        NomResp = "Responsable Relations Extérieures",
                        Description = "Gère les relations avec les partenaires externes et les institutions."
                    },
                    new ResponsabiliteAdministrative
                    {

                        NomResp = "Responsable Formation Personnel",
                        Description = "Supervise et organise la formation du personnel de l'entreprise."
                    },
                    new ResponsabiliteAdministrative
                    {

                        NomResp = "Président de Commission des Œuvres Sociales",
                        Description = "Supervise les activités sociales au sein de l'organisation."
                    },
                    new ResponsabiliteAdministrative
                    {

                        NomResp = "Président du Conseil de Discipline",
                        Description = "Gère les affaires disciplinaires au sein de l'organisation."
                    }
                );

                context.SaveChanges();
            }

            // Seed Employes with Algerian names and locations
            if (!context.Employes.Any())
            {
                context.Employes.AddRange(
                    new Employe
                    {
                        NSS = "1234567890",
                        Nom = "Bouzid",
                        Prenom = "Ahmed",
                        DateNaissance = new DateTime(1985, 5, 15),
                        LieuNaissance = "Alger",
                        Sexe = Sexe.Masculin,
                        SituationFamiliale = SituationFamiliale.Marie,
                        Adresse = "20 Rue des Martyrs, Alger",
                        DateRecrutement = new DateTime(2010, 3, 1),
                        FonctionPrincipale = "Responsable de Projet",
                        Grade = "Cadre",
                        NombreEnfants = 2,
                        Categorie = "Gestion",
                        Section = "Direction de Projet",
                        TauxIndemniteNuisance = 10.5m,
                        PrimeVariable = 1500,
                        Responsabilites = new List<ResponsabiliteAdministrative>
                        {
                        new ResponsabiliteAdministrative { Description = "Responsable de Post" },
                        new ResponsabiliteAdministrative { Description = "Chef Projet" }
                        }
                    },
                    new Employe
                    {
                        NSS = "2345678901",
                        Nom = "Mebarki",
                        Prenom = "Sofia",
                        DateNaissance = new DateTime(1990, 8, 22),
                        LieuNaissance = "Oran",
                        Sexe = Sexe.Feminin,
                        SituationFamiliale = SituationFamiliale.Celibataire,
                        Adresse = "30 Boulevard de la Liberté, Oran",
                        DateRecrutement = new DateTime(2015, 6, 15),
                        FonctionPrincipale = "Chef de Département",
                        Grade = "Manager",
                        NombreEnfants = 0,
                        Categorie = "Administratif",
                        Section = "Ressources Humaines",
                        TauxIndemniteNuisance = 8.5m,
                        PrimeVariable = 1200,
                        Responsabilites = new List<ResponsabiliteAdministrative>
                        {
                        new ResponsabiliteAdministrative { Description = "Chef Département" },
                        new ResponsabiliteAdministrative { Description = "Responsable Formation Personnel" }
                        }
                    }
                );

                context.SaveChanges();
            }
        }
        
    }
}
