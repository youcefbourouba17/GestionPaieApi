using GestionPaieApi.Models;

namespace GestionPaieApi.Interfaces
{
    public interface IBulletinSalaireRepo
    {
        #region get
        Task<BulletinDeSalaire> GetBulletinDeSalaireByID(string id);

        Task<List<BulletinDeSalaire>> SearchBulletinsAsyncByEmployeeID(string searchTerm);
        Task<List<BulletinDeSalaire>> GetAllBulletinsAsyncByMonth(string searchTerm);
        Task<bool> CheckBultinAsync(string employeID);
        Task<BulletinDeSalaire> GetBulletinByEmployeID(string employeID,int month);


        Task<List<Employe>> GetUntachmntEmployeeBultin(int month, int year);
        #endregion

        #region post
        Task SaveBulletin(BulletinDeSalaire bulletin);
        #endregion

    }
}
