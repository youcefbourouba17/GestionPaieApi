using GestionPaieApi.Enum;
using GestionPaieApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionPaieApi.Data
{
    public class SeedData
    {
        public static void Initialize(Db_context context)
        {
            // Seed ResponsabilitesAdministratives
            if (!context.ResponsabilitesAdministratives.Any())
            {
                var responsibilities = new List<ResponsabiliteAdministrative>
                {
                    new ResponsabiliteAdministrative
                    {
                        ResponsabiliteID = "RESP001",
                        NomResp = "Responsable de Post",
                        Description = "Responsable du bon fonctionnement du bureau ou du poste."
                    },
                    new ResponsabiliteAdministrative
                    {
                        ResponsabiliteID = "RESP002",
                        NomResp = "Chef Département",
                        Description = "Chef d'un département, gère les activités et ressources du département."
                    },
                    new ResponsabiliteAdministrative
                    {
                        ResponsabiliteID = "RESP003",
                        NomResp = "Chef Service",
                        Description = "Responsable d'un service spécifique dans une organisation."
                    },
                    new ResponsabiliteAdministrative
                    {
                        ResponsabiliteID = "RESP004",
                        NomResp = "Chef Projet",
                        Description = "Responsable de la gestion et coordination d'un projet."
                    },
                    new ResponsabiliteAdministrative
                    {
                        ResponsabiliteID = "RESP005",
                        NomResp = "Responsable Relations Extérieures",
                        Description = "Gère les relations avec les partenaires externes et les institutions."
                    },
                    new ResponsabiliteAdministrative
                    {
                        ResponsabiliteID = "RESP006",
                        NomResp = "Responsable Formation Personnel",
                        Description = "Supervise et organise la formation du personnel de l'entreprise."
                    },
                    new ResponsabiliteAdministrative
                    {
                        ResponsabiliteID = "RESP007",
                        NomResp = "Président de Commission des Œuvres Sociales",
                        Description = "Supervise les activités sociales au sein de l'organisation."
                    },
                    new ResponsabiliteAdministrative
                    {
                        ResponsabiliteID = "RESP008",
                        NomResp = "Président du Conseil de Discipline",
                        Description = "Gère les affaires disciplinaires au sein de l'organisation."
                    }
                };

                context.ResponsabilitesAdministratives.AddRange(responsibilities);
                context.SaveChanges();
            }

            // Seed Employes
            if (!context.Employes.Any())
            {
                var employes = new List<Employe>
                {
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
                        Precarite= PrecariteType.CDD,
                        Categorie = "Gestion",
                        Section = "Direction de Projet",
                        TauxIndemniteNuisance = 10.5m,
                        PrimeVariable = 1500
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
                        Precarite= PrecariteType.CDI,
                        Categorie = "Administratif",
                        Section = "Ressources Humaines",
                        TauxIndemniteNuisance = 8.5m,
                        PrimeVariable = 1200
                    }
                };

                context.Employes.AddRange(employes);
                context.SaveChanges();
            }

            // Seed EmployeResponsabilites
            if (!context.EmployeResponsabilites.Any())
            {
                var employeResponsibilities = new List<EmployeResponsabilites>
                {
                    // Assign responsibilities to Bouzid Ahmed
                    new EmployeResponsabilites
                    {
                        EmployeID = "1234567890",
                        ResponsabiliteID = "RESP001" // Responsable de Post
                    },
                    new EmployeResponsabilites
                    {
                        EmployeID = "1234567890",
                        ResponsabiliteID = "RESP004" // Chef Projet
                    },

                    // Assign responsibilities to Mebarki Sofia
                    new EmployeResponsabilites
                    {
                        EmployeID = "2345678901",
                        ResponsabiliteID = "RESP002" // Chef Département
                    },
                    new EmployeResponsabilites
                    {
                        EmployeID = "2345678901",
                        ResponsabiliteID = "RESP006" // Responsable Formation Personnel
                    }
                };

                context.EmployeResponsabilites.AddRange(employeResponsibilities);
                context.SaveChanges();
            }
            if (!context.Pointages.Any())
            {
                var pointages = new List<Pointage>
                {
                        new Pointage
                    {
                        Date = new DateTime(2024, 12, 14),
                        EmployeId = "2345678901",
                        DebutMatinee = new TimeSpan(8, 0, 0),
                        FinMatinee = new TimeSpan(12, 0, 0),
                        DebutApresMidi = new TimeSpan(13, 0, 0),
                        FinApresMidi = new TimeSpan(17, 0, 0),
                        DureeDePause = new TimeSpan(1, 0, 0),
                        HeuresSupplementaires = 2.0,
                        HeuresTotales = 10.0
                    },
                    new Pointage
                    {
                        Date = new DateTime(2024, 12, 15),
                        EmployeId = "2345678901",
                        DebutMatinee = new TimeSpan(8, 30, 0),
                        FinMatinee = new TimeSpan(12, 30, 0),
                        DebutApresMidi = new TimeSpan(14, 0, 0),
                        FinApresMidi = new TimeSpan(18, 0, 0),
                        DureeDePause = new TimeSpan(1, 30, 0),
                        HeuresSupplementaires = 1.5,
                        HeuresTotales = 9.5
                    },
                    new Pointage
                    {
                        Date = new DateTime(2024, 11, 10),
                        EmployeId = "2345678901",
                        DebutMatinee = new TimeSpan(9, 0, 0),
                        FinMatinee = new TimeSpan(12, 0, 0),
                        DebutApresMidi = new TimeSpan(13, 30, 0),
                        FinApresMidi = new TimeSpan(17, 30, 0),
                        DureeDePause = new TimeSpan(1, 30, 0),
                        HeuresSupplementaires = 1.0,
                        HeuresTotales = 8.5
                    },
                    new Pointage
                    {
                        Date = new DateTime(2024, 11, 11),
                        EmployeId = "2345678901",
                        DebutMatinee = new TimeSpan(8, 0, 0),
                        FinMatinee = new TimeSpan(11, 30, 0),
                        DebutApresMidi = new TimeSpan(13, 0, 0),
                        FinApresMidi = new TimeSpan(16, 30, 0),
                        DureeDePause = new TimeSpan(1, 0, 0),
                        HeuresSupplementaires = 0.5,
                        HeuresTotales = 8.0
                    },
                    new Pointage
                    {
                        Date = new DateTime(2024, 12, 18),
                        EmployeId = "2345678901",
                        DebutMatinee = new TimeSpan(8, 15, 0),
                        FinMatinee = new TimeSpan(12, 15, 0),
                        DebutApresMidi = new TimeSpan(13, 15, 0),
                        FinApresMidi = new TimeSpan(17, 15, 0),
                        DureeDePause = new TimeSpan(1, 0, 0),
                        HeuresSupplementaires = 2.0,
                        HeuresTotales = 10.0
                    },
                    new Pointage
                    {
                        Date = new DateTime(2024, 12, 20),
                        EmployeId = "2345678901",
                        DebutMatinee = new TimeSpan(9, 0, 0),
                        FinMatinee = new TimeSpan(12, 0, 0),
                        DebutApresMidi = new TimeSpan(13, 30, 0),
                        FinApresMidi = new TimeSpan(17, 0, 0),
                        DureeDePause = new TimeSpan(1, 30, 0),
                        HeuresSupplementaires = 1.5,
                        HeuresTotales = 9.0
                    }

                };

                context.Pointages.AddRange(pointages);
                context.SaveChanges();
            }
            // Seed Pointages for Bouzid Ahmed (30 days)
            if (!context.Pointages.Any(p => p.EmployeId == "1234567890"))
            {
                var pointages = new List<Pointage>();
                DateTime startDate = new DateTime(2024, 12, 1); // starting date

                for (int i = 0; i < 30; i++)
                {
                    DateTime currentDate = startDate.AddDays(i);

                    pointages.Add(new Pointage
                    {
                        Date = currentDate,
                        EmployeId = "1234567890",
                        DebutMatinee = new TimeSpan(8, 0, 0),
                        FinMatinee = new TimeSpan(12, 0, 0),
                        DebutApresMidi = new TimeSpan(13, 0, 0),
                        FinApresMidi = new TimeSpan(17, 0, 0),
                        DureeDePause = new TimeSpan(1, 0, 0),
                        HeuresSupplementaires = 1.0, // Example of extra hours, adjust as necessary
                        HeuresTotales = 8.0 + 1.0 // 8 hours of regular time + 1 hour of overtime
                    });
                }

                context.Pointages.AddRange(pointages);
                context.SaveChanges();
            }
            if (!context.FicheAttachemnts.Any())
            {
                var ficheAttachemnts = new List<FicheAttachemnt>
                {
                    new FicheAttachemnt
                    {
                        JourTravaillee = 20,
                        
                        NomEtPrenom="Bouzid Ahmed",
                        EmployeeID="1234567890",
                        PRC=28,
                        PRI=8,
                        AllocationFamiliale = 100,
                        Remboursement = 150.0,
                        Month = 11,
                        Year = 2024
                    },
                    new FicheAttachemnt
                    {
                        JourTravaillee = 22,
                        NomEtPrenom="Mebarki Sofia",
                        PRC=18,
                        PRI=5,
                        EmployeeID="2345678901",
                        AllocationFamiliale = 150,
                        Remboursement = 200.5,
                        Month = 12,
                        Year = 2024
                    }
                    
                };

                context.FicheAttachemnts.AddRange(ficheAttachemnts);
                context.SaveChanges();
            }

            if (!context.GrilleSalaires.Any())
            {
                var grilleSalaires = new List<GrilleSalaire>
                {
                    new GrilleSalaire
                {
                    NSS_EMPLOYE = "1234567890",
                    
                    BaseSalary = 30000m,
                    Grd = "B1"
                },
                new GrilleSalaire
                {
                    NSS_EMPLOYE = "2345678901",
                    BaseSalary = 40000m,
                    Grd = "A2"
                }

                };

                context.GrilleSalaires.AddRange(grilleSalaires);
                context.SaveChanges();
            }

        }
    }
}
