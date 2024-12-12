using GestionPaieApi.Data;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionPaieApi.Reposotories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly Db_context _context;
        public EmployeeRepo(Db_context context) {
            _context=context;
        }

        public  async Task<ResponsabiliteAdministrative?> GetEmployeeResponsabilitiesByID(String id)
        {
            return await _context.EmployeResponsabilites
                        .Where(er => er.EmployeID == id)
                        .Select(er => er.Responsabilite)
                        .FirstOrDefaultAsync();
        }

        public async Task<List<Employe>> SearchUsersAsync(string searchTerm)
        {
            return await _context.Employes.
                         Where(u => u.NSS.Contains(searchTerm) ||
                         u.Nom.Contains(searchTerm) ||
                         u.Prenom.Contains(searchTerm)).ToListAsync();
        }
        public async Task<bool> CheckEmployeeAsync(string employeID)
        {

            return await _context.Employes.FindAsync(employeID) != null;
        }
        public async Task<Employe?> GetEmployeeByID(string employeID)
        {
            return await _context.Employes.FindAsync(employeID);
        }

        public async Task<double> GetTotalWorkingDay(string employeID, int year, int month)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int totalWorkingHoursInMonth = daysInMonth switch
            {
                28 or 29 => 160, 
                30 => 168,       
                31 => 176,      
                _ => 160         
            };

            var totalWorkedHours = await _context.Pointages
                .Where(c => c.EmployeId == employeID &&
                            c.Date.Year == year &&
                            c.Date.Month == month)
                .SumAsync(c => c.HeuresTotales ?? 0);

            
            return totalWorkedHours / totalWorkingHoursInMonth;
        }

        public async Task<int?> AllocationFamiliale(string employeID)
        {

            return await _context.Employes
                .Where(c => c.NSS == employeID)
                .Select(e => e.NombreEnfants)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Employe>> GetUntachmntEmployeeFiche(int month, int year)
        {
            return await _context.Employes
            .Where(t1 => !_context.FicheAttachemnts.Any(t2 => t2.EmployeeID == t1.NSS && t2.Month==month &&
                                                        t2.Year==year))
            .ToListAsync();
        }

        
    }
}
