

namespace GymUpShop.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly GymUpShopDbContext _gymUpShopDbContext;

        public CategoryRepository(GymUpShopDbContext gymUpShopDbContext)
        {
            _gymUpShopDbContext = gymUpShopDbContext;
        }

        public IEnumerable<Category> AllCategories => 
            _gymUpShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
