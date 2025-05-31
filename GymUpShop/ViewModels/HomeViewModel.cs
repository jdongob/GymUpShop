using GymUpShop.Models;

namespace GymUpShop.ViewModels
{
    public class HomeViewModel //Solo contendra una Lista este ViewModel
    {
        public IEnumerable<Equipment> EquipmentsOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Equipment> equipmentsOfTheWeek)
        {
            EquipmentsOfTheWeek = equipmentsOfTheWeek;
        }
    }
}
