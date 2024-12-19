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
       
        #region BulletinSalaire
        public async Task<BulletinDeSalaire?> GetBulletinByEmployeID(string employeID, int month)
        {
            var bulltin = await _context.BulletinDeSalaires.Include(c => c.FicheAttachemnt)
                .Where(ic => ic.FicheAttachemnt.EmployeeID == employeID &&
                             ic.FicheAttachemnt.Month == month).FirstOrDefaultAsync();

            return bulltin;
        }
        public Task<bool> CheckBultinAsync(string employeID)
        {
            throw new NotImplementedException();
        }
        //todo-- do this motherfucker
        public async Task<List<BulletinDeSalaire>?> GetAllBulletinsAsyncByMonth(int month,int year)
        {
            try
            {
                //var ficheIds = await _context.FicheAttachemnts
                //.Where(c => c.Month == month && c.Year == year)
                //.ToListAsync();


                //return await _context.BulletinDeSalaires
                //.Where(c => ficheIds.FaID.Contains(c.Id_FichAtachemnt)).tolistAsycn();
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching bulletins: {ex.Message}");
                return null;

            }
            
            
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


        public async Task<GrilleSalaire?> GetGrilleSalaireByEmployeID(string employeID)
        {
            return await _context.GrilleSalaires
                            .Where(c => c.NSS_EMPLOYE == employeID)
                            .FirstOrDefaultAsync();
        }
        #endregion

        public async Task SaveBulletin(BulletinDeSalaire bulletin)
        {
            await _context.BulletinDeSalaires.AddAsync(bulletin);
            await _context.SaveChangesAsync();
        }

        public Task<List<BulletinDeSalaire>> GetAllBulletinByEmployeID(string employeID)
        {
            throw new NotImplementedException();
        }
    }
}
