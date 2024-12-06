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

        public  async Task<ResponsabiliteAdministrative> GetEmployeeResponsabilitiesByID(String id)
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
    }
}
