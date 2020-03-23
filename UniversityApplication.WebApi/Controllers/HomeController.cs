using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityApplication.Data.DTOs;
using UniversityApplication.Service.Service;
using UniversityApplication.WebApi.Models;

namespace UniversityApplication.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Data.UniversityDataContext _dbContext;
        private readonly ITranscriptService _service;

        public HomeController(ILogger<HomeController> logger, Data.UniversityDataContext dbContext, ITranscriptService service)
        {
            _logger = logger;
            _dbContext = dbContext;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var addresses = _dbContext.Addresses
                .Include(address => address.Students);

            var students = _dbContext.Students
                .Include(student => student.Address)
                .Include(student => student.Exams)
                .ThenInclude(exam => exam.Exam);

            var exams = _dbContext.Exams;
            var transcripts = _dbContext.Transcripts;

            var t = _service.GetTranscript(2, 1);
            var a = _service.GetTranscripts();

            var tDTO = new TranscriptDTO
            {
                ExamId = 1,
                StudentId = 5,
                Points = 30
            };

            t = _service.SaveTranscript(tDTO);
            tDTO.Points = 60;

            t = _service.PutPoints(t.Id, tDTO);

            _service.DeleteTranscript(t.Id);

            return View();
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
