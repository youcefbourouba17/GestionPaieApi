using GestionPaieApi.Models;

namespace GestionPaieApi.Services
{
    public class BulletinSalaireSevice
    {

        public decimal? Calcul_Salaie(BulletinDeSalaire bulletin)
        {

            if (bulletin.FicheAttachemnt.JourTravaillee != 0)
            {
                return bulletin.GrilleSalaire.BaseSalary *
                            (bulletin.FicheAttachemnt.JourTravaillee / 28);
            }
            return null;
            
        }
    }
}
