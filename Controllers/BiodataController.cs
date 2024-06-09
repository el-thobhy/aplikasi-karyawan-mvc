using aplikasi_karyawan_fe_mvc.Models;
using aplikasi_karyawan_fe_mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace aplikasi_karyawan_fe_mvc.Controllers
{
    public class BiodataController : Controller
    {
        private readonly BiodataServices _service;
        public BiodataController(IConfiguration config)
        {
            _service = new BiodataServices(config["ApiUrl"]);
        }

        public IActionResult Index(string StringSearch)
        {
            List<BiodataViewModel>? data = String.IsNullOrEmpty(StringSearch) ? _service.GetAll() : _service.GetAllFilter(StringSearch);
            ViewBag.Title = "Biodata";
            ViewBag.Filter = StringSearch;
            return View(data);
        }
    }
}
