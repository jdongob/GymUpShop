using GymUpShop.Models;
using GymUpShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymUpShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public HomeController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public IActionResult Index()
        {
            //Voy a traer una Lista.--> Todos los Pies/Equipment de la semana.

            //Si quiero traer 1 registro, de frente envio mi solicitud y recogo ese valor en una variable var, y envio return View(entidad) como una Entidad. en mi vista sera: Models.Equipment; x el View Import, solo pondre Equipment. en mi vista
            //Pero si quiero traer MUCHOS registros, como una LISTA y encima 1 string y encima 1 fecha, eso no lo puede SOSTENERE LA APLICACION, xq solo existe en el MODELS "Entidades". Para esto se crea en la APLICACION, el famoso ViewModels, que es como un wrap de todo lo que necesitas para enviar a la VIsta. En la vista recibiras ya NO una Entidad sino Un ViewModel

            //Solo si quiere traer 1 Registro, es decir una entidad (equipment o categoria) lo puedes hacer de frente, Pero si quieres MUCHOS REGISTROS, coomo una LISTA, eso tiene que ser por ViewModel. porque el Proyecto solo sostiene ENTIDAD(1 Registro) o ViewMODEL ( MUCHAS COSAS DIFERENTES A 1 REGISTRO, EJ: UNA LISTA, o Una Lista + string o String+ numerico, cualquiere cosas todo se hace WRAP y se envia atraves de un ViewModel

            //Solo hay 2 opciones pedir a la bd por 1 registro (ENTIDAD) o pedir diferente a 1 registro, como lista, como lista mas string,etc en este caso sera VIEWMODEL
            // 2 Opciones : Entidad (1 registro) o ViewModel(wrap diferentes registros o cadenas)


            //Index action, me traera "Todos los pies/equipment de la semana" de la BD es decir una Lista y se pasara como un (ViewModel) list. Otra forma de pedir una LISTA de la bd si usar la variable var esta el codigo en  "EquipmentController" y action "List"

            var equipOfTheWeek = _equipmentRepository.EquipmentsOfTheWeek; //Obteniendo Lista BD
            var homeViewModel = new HomeViewModel(equipOfTheWeek); //Pasando la lista al ViewModel
            return View(homeViewModel);  //En este caso Pasamos a la Vista un "ViewModel" (list)

            // A una Vista SOLO se puede pasar 2 opciones: Entidad (1 registro) o ViewModel (Wrap de Varios Registros lIst ademas diferentes data como string, date,etc)
        }
    }
}
