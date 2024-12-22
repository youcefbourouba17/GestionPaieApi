using GestionPaieApi.Models;

namespace GestionPaieApi.Services
{
    public static class BulletinSalaireSevice
    {

        public static decimal Calcul_Salaie(BulletinDeSalaire bulletin)
        {
            int totalDaysInMonth = 29; 
            int daysWorked = bulletin.FicheAttachemnt.JourTravaillee;

            if (daysWorked > 0)
            {
                decimal dailyRate = bulletin.GrilleSalaire.BaseSalary / totalDaysInMonth;
                decimal proratedSalary = dailyRate * daysWorked;

                
                return Math.Round(proratedSalary, 2);
            }

            return 0; 
        }

    }
}
