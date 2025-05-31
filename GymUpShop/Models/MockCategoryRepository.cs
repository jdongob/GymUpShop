
namespace GymUpShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category {CategoryId=1, CategoryName="Strength", Description="All Strength Equipment"},
                new Category {CategoryId=2, CategoryName="Conditioning", Description="Exercise Recovery"},
                new Category {CategoryId=3, CategoryName="Weights and Bars", Description="Weights and Bars"},
                new Category {CategoryId=4, CategoryName="Storage", Description="Storage"},
                new Category {CategoryId=5, CategoryName="Gym Accessories", Description="Gym Accessories"}
            };
    }
}
