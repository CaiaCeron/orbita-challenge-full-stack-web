using apiCadastro.Models;
using apiCadastro.ViewModels;
using CadastroApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace apiCadastro.Controllers
{
    public class HomeController : Controller
    {
        private readonly CadastroDataContext context;

        public HomeController(CadastroDataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var students = this.context.Students.Select(s=>new StudentView
            {
                AcademicRegistry = s.AcademicRegistry,
                Cpf = s.Cpf,
                Name = s.Name,
                Email = s.Email,
            });
            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}