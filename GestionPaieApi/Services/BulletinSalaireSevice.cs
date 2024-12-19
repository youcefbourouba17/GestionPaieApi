using GestionPaieApi.Models;

namespace GestionPaieApi.Services
{
    public static class BulletinSalaireSevice
    {

        public static decimal Calcul_Salaie(BulletinDeSalaire bulletin)
        {

            if (bulletin.FicheAttachemnt.JourTravaillee != 0)
            {
                return bulletin.GrilleSalaire.BaseSalary *
                            (bulletin.FicheAttachemnt.JourTravaillee / 28);
            }
            return 0;
            
        }
    }
}
