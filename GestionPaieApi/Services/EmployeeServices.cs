using GestionPaieApi.Models;

namespace GestionPaieApi.Services
{
    public static class EmployeeServices
    {

        public static double? GetTotalHours(Pointage pointage)
        {

            double totalHoursWithoutSupp =
            (pointage.FinApresMidi.GetValueOrDefault() - pointage.DebutMatinee.GetValueOrDefault() -
             pointage.DureeDePause.GetValueOrDefault()).TotalHours;

            return totalHoursWithoutSupp + (pointage.HeuresSupplementaires * 1.5);
        }
    }
}
