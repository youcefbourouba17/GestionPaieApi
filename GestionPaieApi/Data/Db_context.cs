using GestionPaieApi.DTOs;
using GestionPaieApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionPaieApi.Data
{
    public class Db_context : DbContext  
    {
        public Db_context(DbContextOptions<Db_context> option) : base(option)
        {

        }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<ResponsabiliteAdministrative> ResponsabilitesAdministratives { get; set; }
        public DbSet<EmployeResponsabilites> EmployeResponsabilites { get; set; }
        public DbSet<Pointage> Pointages { get; set; }
        public DbSet<FicheAttachemnt> FicheAttachemnts { get; set; }
        public DbSet<GrilleSalaire> GrilleSalaires { get; set; }
        public DbSet<BulletinDeSalaire> BulletinDeSalaires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// EmployeResponsabilites
            modelBuilder.Entity<EmployeResponsabilites>()
            .HasKey(er => er.EmployeResponsabilitesId);

            modelBuilder.Entity<EmployeResponsabilites>()
                .HasOne(er => er.Employe)
                .WithMany(e => e.EmployeResponsabilites)
                .HasForeignKey(er => er.EmployeID);

            modelBuilder.Entity<EmployeResponsabilites>()
                .HasOne(er => er.Responsabilite)
                .WithMany(r => r.EmployeResponsabilites)
                .HasForeignKey(er => er.ResponsabiliteID);

            modelBuilder.Entity<Pointage>()
                .HasKey(p => new { p.EmployeId, p.Date });
            //// ResponsabiliteAdministrative
            modelBuilder.Entity<ResponsabiliteAdministrative>()
            .HasIndex(e => e.NomResp)
            .IsUnique();

            //// fiche attachemnt
            modelBuilder.Entity<FicheAttachemnt>()
                .HasKey(p => new { p.Month, p.Year,p.EmployeeID });
            modelBuilder.Entity<FicheAttachemnt>()
                .HasOne(f => f.Employe)
                .WithMany() 
                .HasForeignKey(f => f.EmployeeID);

            // grille salaire
            modelBuilder.Entity<GrilleSalaire>(entity =>
            {
                entity.Property(e => e.BaseSalary)
                      .HasPrecision(18, 2); 
            });
            modelBuilder.Entity<GrilleSalaire>()
            .HasIndex(b => b.NSS_EMPLOYE)
            .IsUnique();


            // bultin slary

            modelBuilder.Entity<BulletinDeSalaire>()
            .HasIndex(b => b.Id_FichAtachemnt)
            .IsUnique();


            //SeedData.Initialize(this);
        }
    }
}
