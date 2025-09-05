using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MVC_POE.Models;
using MVC_POE.Services;

namespace MVC_POE.Controllers
{
    public class ReportIssuesController : Controller
    {
        private readonly HashSetService _hashSetService;
        private readonly IWebHostEnvironment _webHost;
        public ReportIssuesController(HashSetService hashSetService, IWebHostEnvironment webHost)
        {
            _hashSetService = hashSetService;
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            return View();
        }

        // Displays the form for citizens to submit
        [HttpGet]
        public IActionResult CreateReportIssues()
        {
            return View();
        }

        //// Handles form submission
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateReportIssues(ReportIssuesForm reportIssuesForm)
        //{
        //    // If FormId was empty (new submission), generate a new one
        //    if (reportIssuesForm.FormId == Guid.Empty)
        //    {
        //        reportIssuesForm.FormId = Guid.NewGuid();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _hashSetService.AddForm(reportIssuesForm);
        //        return RedirectToAction("ViewReportIssues");
        //    }

        //    return View(reportIssuesForm);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateReportIssues(ReportIssuesForm reportIssuesForm, IFormFile? file)
        {
            // Ensure a FormId is generated if not provided
            if (reportIssuesForm.FormId == Guid.Empty)
            {
                reportIssuesForm.FormId = Guid.NewGuid();
            }

            // Handle file upload only if a file was provided
            if (file != null && file.Length > 0)
            {
                string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

                if (!Directory.Exists(uploadFolder)) // Create folder if it doesn’t exist
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string fileName = Path.GetFileName(file.FileName);
                string fileSavePath = Path.Combine(uploadFolder, fileName);

                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Save path/filename to the form object
                reportIssuesForm.MediaAttachment = fileName;

                ViewBag.Message = fileName + " uploaded successfully!";
            }

            if (ModelState.IsValid)
            {
                _hashSetService.AddForm(reportIssuesForm);
                return RedirectToAction("ViewReportIssues");
            }

            return View(reportIssuesForm);
        }


        // Displays all submissions
        public IActionResult ViewReportIssues()
        {
            var reportIssueForms = _hashSetService.GetAllForms();
            return View(reportIssueForms);
        }

    }
}
