using GestionPaieApi.Models;

namespace GestionPaieApi.Interfaces
{
    public interface IBulletinSalaireRepo
    {
        #region Get
        Task<BulletinDeSalaire?> GetBulletinDeSalaireByIDAsync(int id);

        Task<List<BulletinDeSalaire>> SearchBulletinsAsyncByEmployeeIDAsync(string searchTerm);

        Task<List<BulletinDeSalaire>> GetAllBulletinsAsyncByMonthAsync(int month, int year);

        Task<bool> CheckBulletinExistsAsync(string employeID);

        Task<BulletinDeSalaire?> GetBulletinByEmployeIDAsync(string employeID, int month);

        Task<List<BulletinDeSalaire>> GetAllBulletinsByEmployeIDAsync(string employeID);

        Task<GrilleSalaire?> GetGrilleSalaireByEmployeIDAsync(string employeID);

        Task<List<Employe>> GetUntachedEmployeeBulletinsAsync(int month, int year);
        #endregion

        #region Post
        Task SaveBulletinAsync(BulletinDeSalaire bulletin);
        #endregion
    }
}
