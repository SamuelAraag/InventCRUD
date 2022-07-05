using Microsoft.AspNetCore.Mvc;

namespace CRUD.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
