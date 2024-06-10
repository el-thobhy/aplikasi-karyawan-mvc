using aplikasi_karyawan_fe_mvc.AddOns;
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

        public IActionResult Index(string? StringSearch, string? orderBy, int? pageSize, int? pageNum)
        {
            ViewBag.Title = "Biodata";
            ViewBag.Filter = StringSearch;
            ViewBag.PageSize = pageSize??2;
            List<BiodataViewModel> empty = new List<BiodataViewModel>();
            ResponseResult? data = _service.GetAllFilter(StringSearch??"", pageNum ?? 1, pageSize??2);

            //page
            return View(Pagination<BiodataViewModel>.Create(data.Data ?? empty, data.Pages, pageNum??1));
        }
    }
}
