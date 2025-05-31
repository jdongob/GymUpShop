using GymUpShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymUpShop.Components
{
    public class CategoryEquipment : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryEquipment(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.AllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }

    }
}
