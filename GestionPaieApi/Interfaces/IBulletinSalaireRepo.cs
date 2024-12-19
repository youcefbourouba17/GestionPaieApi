using GestionPaieApi.Models;

namespace GestionPaieApi.Interfaces
{
    public interface IBulletinSalaireRepo
    {
        #region get
        Task<BulletinDeSalaire> GetBulletinDeSalaireByID(string id);

        Task<List<BulletinDeSalaire>> SearchBulletinsAsyncByEmployeeID(string searchTerm);
        Task<List<BulletinDeSalaire>> GetAllBulletinsAsyncByMonth(int month,int year);
        Task<bool> CheckBultinAsync(string employeID);
        Task<BulletinDeSalaire> GetBulletinByEmployeID(string employeID,int month);
        Task<List<BulletinDeSalaire>> GetAllBulletinByEmployeID(string employeID);

        Task<GrilleSalaire?> GetGrilleSalaireByEmployeID(string employeID);


        Task<List<Employe>> GetUntachmntEmployeeBultin(int month, int year);
        #endregion

        #region post
        Task SaveBulletin(BulletinDeSalaire bulletin);
        #endregion

    }
}
