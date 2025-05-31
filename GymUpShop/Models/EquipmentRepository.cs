
using Microsoft.EntityFrameworkCore;

namespace GymUpShop.Models
{
    public class EquipmentRepository: IEquipmentRepository
    {
        private readonly GymUpShopDbContext _gymUpShopDbContext;

        public EquipmentRepository(GymUpShopDbContext gymUpShopDbContext)
        {
            _gymUpShopDbContext = gymUpShopDbContext;
        }

        public IEnumerable<Equipment> AllEquipments
        {
            get 
            {
                return _gymUpShopDbContext.Equipments.Include(c => c.Category);
            }
        }
        public IEnumerable<Equipment> EquipmentsOfTheWeek
        {
            get
            {
                return _gymUpShopDbContext.Equipments.Include(c => c.Category).Where(p =>
                p.IsEquipmentOfTheWeek);
            }
        }

        public Equipment? GetEquipmentById(int equipmentId)
        {
            return _gymUpShopDbContext.Equipments.FirstOrDefault(p => p.EquipmentId == equipmentId);
        }

        public IEnumerable<Equipment> SearchEquipments(string searchQuery)
        {
            throw new NotImplementedException();
        }


    }
}
