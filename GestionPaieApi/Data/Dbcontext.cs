using GestionPaieApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionPaieApi.Data
{
    public class Dbcontext : DbContext  
    {
        public Dbcontext(DbContextOptions<Dbcontext> option) : base(option)
        {

        }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<ResponsabiliteAdministrative> ResponsabilitesAdministratives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            SeedData.Initialize(this);
        }
    }
}
