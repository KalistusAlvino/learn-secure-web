using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SecureWeb.Data;
using SecureWeb.Models;

namespace SecureWeb.Controllers
{
    public class StudentController : Controller
    {
        public StudentController(IMahasiswa dataMahasiswa)
        {
            _dataMahasiswa = dataMahasiswa;
        }
        private readonly IMahasiswa _dataMahasiswa;


        public IActionResult Index()
        {
            var students = _dataMahasiswa.GetMahasiswa();
            return View(students);
        }
        [HttpPost]
        public IActionResult Create(Mahasiswa mahasiswas)
        {
            try
            {
                _dataMahasiswa.AddStudent(mahasiswas);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(mahasiswas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}