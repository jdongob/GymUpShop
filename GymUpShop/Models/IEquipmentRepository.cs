using System.IO.Pipelines;

namespace GymUpShop.Models
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> AllEquipments { get; }
        IEnumerable<Equipment> EquipmentsOfTheWeek { get; }
        Equipment? GetEquipmentById(int equipmentId);
        IEnumerable<Equipment> SearchEquipments(string searchQuery);
    }
}
