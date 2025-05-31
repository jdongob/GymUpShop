using GymUpShop.Models;
using GymUpShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace GymUpShop.Controllers
{
    public class EquipmentController : Controller
    {
        // Obterner toda la DATA que quieres para trabajar en el controller x Construcion Inyeccion. (accediendo a los Interfaces y por ende a los MocksRepository k es la implementacion sql,list, etc}
        // ACCEDER A LOS MOCK DONDE ESTA TODA LA IMPLEMENTACION MOCKPIE.ALL PIES.  (TRAE UN LIST DE PIES).

        // y crear tu metodo q quieres, en este caso List
        // Pasar al VIEW para VER Toda la DATA OBTENIDA del CONTROLLER 


        private readonly IEquipmentRepository _equipmentRepository;
        private readonly ICategoryRepository _categoryRepository;

        public EquipmentController(IEquipmentRepository equipmentRepository, ICategoryRepository categoryRepository)
        {
            _equipmentRepository = equipmentRepository;
            _categoryRepository = categoryRepository;
        }
         
       /*
        ----   OLD Action Method :List ---
        public IActionResult List()
        {
            // ViewModel :
             
             * Cuando necesites pasar diferentes piezas de data a la Vista (View),de varias fuentes diferentes, no solo de Domain data, es decir no solo de las clases de la Base de dato
             * como aqui queremos pasar un IEnumerable(AllPies) esto es domain data es una clase de Models que esta en la BD  y un String ("Strength")
             
             *Tenemos que usar un ViewModel, que es como un modelo customizado,preparado para nuestra View.
             *ViewModel ( un modelo para nuestro View) a model for the View = ViewModel class. 
             *pasamos en UNA toda la data que necesitamos compartir entre el Controller y el View
            
              Entonces la diferente data que queremos pasar ==> son properties para mi ViewModel Class que vamos a crear
              una propiedad IEnumerable ( que seria para AllPies, xq devuelve IEnumerable )
              y una propiedad String ( que seria para pasar "Strength", que aqui se pasa usando el metodo ViewBag.
            
             //


            //ViewBag.CurrentCategory = "Strength";
            //return View(_equipmentRepository.AllEquipments);  //Retorna una List (hay 6 registros en duro en el MockEquiqmentRepository, al Inicializar el Intreface en el Constructor, inyectamos y podemos trabajar con todos los Metodos en el MockRepository)

            EquipmentListViewModel equipmentsListViewModel = new EquipmentListViewModel(
                _equipmentRepository.AllEquipments, "All Equipments");

            return View(equipmentsListViewModel); //La vista "List" ahora tiene que recibir este ViewModel          
        
        }
       */

        public ViewResult List(string category) //ViewResult: Es un tipo de IActionResult y render una View.
        {
            //Declaracion de 2 variables generales
            IEnumerable<Equipment> equipment;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
               equipment = _equipmentRepository.AllEquipments.OrderBy(e => e.EquipmentId);
               currentCategory = "All equipments";
            }
            else
            {
                equipment = _equipmentRepository.AllEquipments.Where(e => e.Category.CategoryName == category)
                        .OrderBy(e => e.EquipmentId);
                currentCategory = _categoryRepository.AllCategories
                        .FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
             }

            return View(new EquipmentListViewModel(equipment, currentCategory));    

        }
        public IActionResult Details(int id)
        {
            var equipt = _equipmentRepository.GetEquipmentById(id); //Devuelve 1 solo registro de Equipmet de la BD segun su ID, una entidad Equipment con toda su data ( name, price, etc) pero 1 solo registro.
            if (equipt == null)
                return NotFound();
            return View(equipt); //Devuelve 1 solo registro de BD, 1 entidad Equipment con su data (name, price,img,etc)
        }
        
        
    }
}
