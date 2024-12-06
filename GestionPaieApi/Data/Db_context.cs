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

            //// ResponsabiliteAdministrative
            modelBuilder.Entity<ResponsabiliteAdministrative>()
            .HasIndex(e => e.NomResp)
            .IsUnique();



            //SeedData.Initialize(this);
        }
    }
}
