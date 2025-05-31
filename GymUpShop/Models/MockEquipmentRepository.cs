using GymUpShop.Models;

namespace GymUpShop.Models
{
    public class MockEquipmentRepository : IEquipmentRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Equipment> AllEquipments => 
            new List<Equipment>
            {
                new Equipment{EquipmentId = 1, Name="Benches",     Price=15.95M, ShortDescription="Lorem Ipsum", LongDescription="A weight bench is a piece of fitness equipment that is used for weight training. Although it is called a “bench”, there are some features that make it distinct from normal benches.",                      Category = _categoryRepository.AllCategories.ToList()[0], ImageUrl="benches.jpg", InStock=true, IsEquipmentOfTheWeek=true, ImageThumbnailUrl="/Images/categories/benchesmall.jpg"},
                new Equipment{EquipmentId = 2, Name="Power Racks", Price=18.95M, ShortDescription="Lorem Ipsum", LongDescription="A power rack, also known as a power cage or squat cage, is a piece of common fitness equipment in a commercial gym and home gym. It has become extremely popular in the home and garage gyms nowadays.",    Category = _categoryRepository.AllCategories.ToList()[0], ImageUrl="",            InStock=true, IsEquipmentOfTheWeek=true, ImageThumbnailUrl="/Images/categories/power_rack_small.jpg" },
                new Equipment{EquipmentId = 3, Name="Mats",        Price=15.95M, ShortDescription="Lorem Ipsum", LongDescription="A range of heavy-duty and large gym mats for home, fitness and gymnastics centre use. Gym Plus provides great value and quality gym flooring to suit your needs for home workout,weightlifting,dance etc.", Category = _categoryRepository.AllCategories.ToList()[1], ImageUrl="",            InStock=true, IsEquipmentOfTheWeek=false,ImageThumbnailUrl="/Images/categories/mat_small.jpg"},
                new Equipment{EquipmentId = 4, Name="Barbells",    Price=12.95M, ShortDescription="Lorem Ipsum", LongDescription="Barbells are the quintessential parts of any Gym or workout Stations. Any strength or weightlifting training is incomplete without the barbells. They allow you to perform resistance training.",           Category = _categoryRepository.AllCategories.ToList()[2], ImageUrl="",            InStock=true, IsEquipmentOfTheWeek=true, ImageThumbnailUrl= "/Images/categories/barbell_small.jpg"},
                new Equipment{EquipmentId = 5, Name="Weight Storage", Price=20M, ShortDescription="Lorem Ipsum", LongDescription="While there are countless resistance machines to choose from, free weights will always be an essential part of toning and strengthening your body. Keep your fitness area organized with storage racks.",   Category = _categoryRepository.AllCategories.ToList()[3], ImageUrl="",            InStock=true, IsEquipmentOfTheWeek=false, ImageThumbnailUrl="/Images/categories/weight_storage_small.jpg"},
                new Equipment{EquipmentId = 6, Name="Holder Accessories",Price=15M, ShortDescription="Lorem Ipsum", LongDescription="From tiny play blocks to large safety mats, from colours to shapes, your vision, our fully tailored customisable solutions!",                                                                               Category = _categoryRepository.AllCategories.ToList()[4], ImageUrl="",            InStock=true, IsEquipmentOfTheWeek=false, ImageThumbnailUrl="/Images/categories/holder_small.jpg"}
            };

        // public IEnumerable<Equipment> EquipmentsOfTheWeek => AllEquipments.Where(e => e.IsEquipmentOfTheWeek);

        public IEnumerable<Equipment> EquipmentsOfTheWeek
        { 
            get
            {
                return AllEquipments.Where(e => e.IsEquipmentOfTheWeek);
            }
        }

        public Equipment? GetEquipmentById(int equipmentId) => AllEquipments.FirstOrDefault(e => e.EquipmentId == equipmentId);
        

        public IEnumerable<Equipment> SearchEquipments(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
