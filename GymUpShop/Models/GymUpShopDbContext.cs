using Microsoft.EntityFrameworkCore;

namespace GymUpShop.Models
{
    public class GymUpShopDbContext: DbContext
    {

        public GymUpShopDbContext(DbContextOptions<GymUpShopDbContext> options) : base(options)
        {
        }

        //Crear lo que seran tablas en la Bd -- con DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> Equipments { get; set; }


    }
}
