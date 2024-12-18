using GestionPaieApi.Data;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionPaieApi.Reposotories
{
    public class BulletinSalaireRepo : IBulletinSalaireRepo
    {
        private Db_context _context;

        public BulletinSalaireRepo(Db_context context)
        {
            _context = context;
        }
        #region Get
        public Task<bool> CheckBultinAsync(string employeID)
        {
            throw new NotImplementedException();
        }

        public Task<List<BulletinDeSalaire>> GetAllBulletinsAsyncByMonth(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task<BulletinDeSalaire?> GetBulletinByEmployeID(string employeID,int month)
        {
            var bulltin =await _context.BulletinDeSalaires.Include(c => c.FicheAttachemnt)
                .Where(ic => ic.FicheAttachemnt.EmployeeID == employeID &&
                             ic.FicheAttachemnt.Month == month).FirstOrDefaultAsync();

            return bulltin;
        }

        public Task<BulletinDeSalaire> GetBulletinDeSalaireByID(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employe>> GetUntachmntEmployeeBultin(int month, int year)
        {
            throw new NotImplementedException();
        }

        public Task<List<BulletinDeSalaire>> SearchBulletinsAsyncByEmployeeID(string searchTerm)
        {
            throw new NotImplementedException();
        }

        #endregion

        public async Task SaveBulletin(BulletinDeSalaire bulletin)
        {
            await _context.BulletinDeSalaires.AddAsync(bulletin);
            await _context.SaveChangesAsync();
        }

        
    }
}
