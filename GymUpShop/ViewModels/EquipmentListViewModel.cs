using GymUpShop.Models;

namespace GymUpShop.ViewModels
{
    public class EquipmentListViewModel  //Contendra una Lista + un String este ViewModel
    {
        public IEnumerable<Equipment> Equipments { get; }
        public string? CurrentCategory { get; }

        public EquipmentListViewModel(IEnumerable<Equipment> equipments, string? currentCategory)
        {
            Equipments = equipments;
            CurrentCategory = currentCategory;
        }
    }
}
