using System.IO.Pipelines;

namespace GymUpShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Equipment>? Equipments { get; set; }

    }
}
