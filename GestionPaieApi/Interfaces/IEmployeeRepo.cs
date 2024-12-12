using GestionPaieApi.DTOs;
using GestionPaieApi.Models;

namespace GestionPaieApi.Interfaces
{
    public interface IEmployeeRepo 
    {
        Task<ResponsabiliteAdministrative> GetEmployeeResponsabilitiesByID(string id);

        Task<List<Employe>> SearchUsersAsync(string searchTerm);
        Task<bool> CheckEmployeeAsync(string employeID);
        Task<Employe> GetEmployeeByID(string employeID);

        Task<double> GetTotalWorkingDay(string employeID,int year,int month);


        Task<List<Employe>> GetUntachmntEmployeeFiche(int month, int year);

    }
}
