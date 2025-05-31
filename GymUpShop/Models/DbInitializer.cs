using System.IO.Pipelines;

namespace GymUpShop.Models
{   
    //Esta Clase solo es creada para Colocar Data de Inicio en las tablas de la BD que estan vacias. 
   // Verifica si ya hay data, No sobreescribe, solamente No inserta nada.
    public static class DbInitializer
    {
        //Aqui no se puede crear Dependency Inyection para traer el DBContext, xeso se usa de parametro "Apllication Builder" ("app" de program.cs)
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            GymUpShopDbContext context = 
                applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<GymUpShopDbContext>();

            if (!context.Categories.Any()) // Si no hay data inserta, sino no hace nada
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Equipments.Any()) // Si no hay data inserta, sino no hace nada
            {
                context.AddRange    
                (
                    new Equipment { Name = "Benches", Price = 15.95M,           ShortDescription = "Lorem Ipsum", LongDescription = "A weight bench is a piece of fitness equipment that is used for weight training. Although it is called a “bench”, there are some features that make it distinct from normal benches.",                     Category = Categories["Strength"],          ImageUrl = "benches.jpg",      InStock = true,      IsEquipmentOfTheWeek = true,        ImageThumbnailUrl = "/Images/categories/benchesmall.jpg" },
                    new Equipment { Name = "Power Racks", Price = 18.95M,       ShortDescription = "Lorem Ipsum", LongDescription = "A power rack, also known as a power cage or squat cage, is a piece of common fitness equipment in a commercial gym and home gym. It has become extremely popular in the home and garage gyms nowadays.",   Category = Categories["Strength"],          ImageUrl = "",                 InStock = true,      IsEquipmentOfTheWeek = true,        ImageThumbnailUrl = "/Images/categories/power_rack_small.jpg" },
                    new Equipment { Name = "Mats", Price = 15.95M,              ShortDescription = "Lorem Ipsum", LongDescription = "A range of heavy-duty and large gym mats for home, fitness and gymnastics centre use. Gym Plus provides great value and quality gym flooring to suit your needs for home workout,weightlifting,dance etc.",Category = Categories["Conditioning"],      ImageUrl = "",                 InStock = true,      IsEquipmentOfTheWeek = false,       ImageThumbnailUrl = "/Images/categories/mat_small.jpg" },
                    new Equipment { Name = "Barbells", Price = 12.95M,          ShortDescription = "Lorem Ipsum", LongDescription = "Barbells are the quintessential parts of any Gym or workout Stations. Any strength or weightlifting training is incomplete without the barbells. They allow you to perform resistance training.",          Category = Categories["Weights and Bars"],  ImageUrl = "",                 InStock = true,      IsEquipmentOfTheWeek = true,        ImageThumbnailUrl = "/Images/categories/barbell_small.jpg" },
                    new Equipment { Name = "Weight Storage", Price = 20M,       ShortDescription = "Lorem Ipsum", LongDescription = "While there are countless resistance machines to choose from, free weights will always be an essential part of toning and strengthening your body. Keep your fitness area organized with storage racks.",  Category = Categories["Storage"],           ImageUrl = "",                 InStock = true,      IsEquipmentOfTheWeek = false,       ImageThumbnailUrl = "/Images/categories/weight_storage_small.jpg" },
                    new Equipment { Name = "Holder Accessories", Price = 15M,   ShortDescription = "Lorem Ipsum", LongDescription = "From tiny play blocks to large safety mats, from colours to shapes, your vision, our fully tailored customisable solutions!",                                                                              Category = Categories["Gym Accessories"],   ImageUrl = "",                 InStock = true,      IsEquipmentOfTheWeek = false,       ImageThumbnailUrl = "/Images/categories/holder_small.jpg" }
                );
            }

            context.SaveChanges();  //Importante este comando SaveChanges, para guardar en BD
        }

        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Strength" },
                        new Category { CategoryName = "Conditioning" },
                        new Category { CategoryName = "Weights and Bars" },
                        new Category { CategoryName = "Storage" },
                        new Category { CategoryName = "Gym Accessories" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }


}
