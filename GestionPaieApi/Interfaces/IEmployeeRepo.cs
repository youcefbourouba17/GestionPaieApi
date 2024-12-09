using GestionPaieApi.DTOs;
using GestionPaieApi.Models;

namespace GestionPaieApi.Interfaces
{
    public interface IEmployeeRepo 
    {
        Task<ResponsabiliteAdministrative> GetEmployeeResponsabilitiesByID(string id);

        Task<List<Employe>> SearchUsersAsync(string searchTerm);
        Task<bool> CheckUserAsync(string employeID);

        Task<double> GetTotalWorkingDay(string employeID,int year,int month);
    }
}
