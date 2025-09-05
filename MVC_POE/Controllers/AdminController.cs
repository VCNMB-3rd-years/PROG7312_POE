using Microsoft.AspNetCore.Mvc;
using MVC_POE.Services;

namespace MVC_POE.Controllers
{
    public class AdminController : Controller
    {
        private readonly HashSetService _hashSetService;

        public AdminController(HashSetService hashSetService)
        {
            _hashSetService = hashSetService;
        }
        public IActionResult Index()
        {
            return View();
        }
        // List all submissions
        public IActionResult ViewReportIssues()
        {
            var reportIssueForms = _hashSetService.GetAllForms();
            return View(reportIssueForms);
        }
    }
}
