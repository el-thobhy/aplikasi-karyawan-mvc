using Microsoft.AspNetCore.Mvc;

namespace aplikasi_karyawan_fe_mvc.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
