using GestionPaieApi.Data;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionPaieApi.Repositories
{
    public class BulletinSalaireRepo : IBulletinSalaireRepo
    {
        private readonly Db_context _context;

        public BulletinSalaireRepo(Db_context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Get

        #region BulletinSalaire

        public async Task<BulletinDeSalaire?> GetBulletinByEmployeIDAsync(string employeID, int month)
        {
            if (string.IsNullOrEmpty(employeID))
            {
                throw new ArgumentException("EmployeID cannot be null or empty", nameof(employeID));
            }

            return await _context.BulletinDeSalaires
                .Include(c => c.FicheAttachemnt)
                .Where(ic => ic.FicheAttachemnt.EmployeeID == employeID &&
                             ic.FicheAttachemnt.Month == month)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CheckBulletinExistsAsync(string employeID)
        {
            if (string.IsNullOrEmpty(employeID))
            {
                throw new ArgumentException("EmployeID cannot be null or empty", nameof(employeID));
            }

            return await _context.BulletinDeSalaires
                .AnyAsync(b => b.FicheAttachemnt.EmployeeID == employeID);
        }

        public async Task<List<BulletinDeSalaire>?> GetAllBulletinsAsyncByMonthAsync(int month, int year)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
            }

            try
            {
                return await _context.BulletinDeSalaires
                    .Include(b => b.FicheAttachemnt)
                    .Where(b => b.FicheAttachemnt.Month == month && b.FicheAttachemnt.Year == year)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., to a file or monitoring service)
                Console.WriteLine($"Error fetching bulletins: {ex.Message}");
                return null;
            }
        }

        public async Task<BulletinDeSalaire?> GetBulletinDeSalaireByIDAsync(int id)
        {
            

            return await _context.BulletinDeSalaires
                .Include(c => c.FicheAttachemnt)
                .Include(ic=> ic.GrilleSalaire)
                .Include(em => em.FicheAttachemnt.Employe)
                .Where(m => m.BulletinDeSalaireID==id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Employe>> GetUntachedEmployeeBulletinsAsync(int month, int year)
        {
            try
            {
                return await _context.Employes
                    .Where(e => !_context.BulletinDeSalaires
                        .Any(b => b.FicheAttachemnt.EmployeeID == e.NSS &&
                                  b.FicheAttachemnt.Month == month &&
                                  b.FicheAttachemnt.Year == year))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error fetching untached employee bulletins: {ex.Message}");
                return new List<Employe>();
            }
        }

        public async Task<List<BulletinDeSalaire>> SearchBulletinsAsyncByEmployeeIDAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                throw new ArgumentException("Search term cannot be null or empty", nameof(searchTerm));
            }

            return await _context.BulletinDeSalaires
                .Where(b => b.FicheAttachemnt.EmployeeID.Contains(searchTerm))
                .ToListAsync();
        }

        #endregion

        #endregion

        public async Task SaveBulletinAsync(BulletinDeSalaire bulletin)
        {
            if (bulletin == null)
            {
                throw new ArgumentNullException(nameof(bulletin), "Bulletin cannot be null");
            }

            await _context.BulletinDeSalaires.AddAsync(bulletin);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BulletinDeSalaire>> GetAllBulletinsByEmployeIDAsync(string employeID)
        {
            if (string.IsNullOrEmpty(employeID))
            {
                throw new ArgumentException("EmployeID cannot be null or empty", nameof(employeID));
            }

            return await _context.BulletinDeSalaires
                .Where(b => b.FicheAttachemnt.EmployeeID == employeID)
                .ToListAsync();
        }

        public async Task<GrilleSalaire?> GetGrilleSalaireByEmployeIDAsync(string employeID)
        {
            return await _context.GrilleSalaires.Where(c => c.NSS_EMPLOYE==employeID).FirstOrDefaultAsync();
        }
    }
}
